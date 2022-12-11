using Microsoft.AspNetCore.OData;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text.Json.Serialization;
using TadataNet.Common.Authorization;
using TadataNet.Common.Helpers;
using TadataNet.Common.Services;
using TadataNet.Services;

namespace TadataNet.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;

        services.AddDbContext<DataContext>();
        services.AddCors();
        services.AddControllers().AddJsonOptions(x =>
        {
            // serialize enums as strings in api responses (e.g. Role)
            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        services.AddControllers().AddOData(options => options.Select().Filter().OrderBy());
        services.AddHttpClient();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { 
                Title = "TadataNet API", 
                Version = "v1", 
                Description = "Bookmark manager with many features"    
            });
        });

        var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();

        logger.Information("Starting Jipnet Api");

        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);

        services.AddScoped<IJwtUtils, JwtUtils>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IApisService, ApisService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ILinksService, LinksService>();
        services.AddScoped<ITagsService, TagsService>();
        services.AddScoped<ISettingsService, SettingsService>();
        services.AddScoped<IUrlsService, UrlsService>();

        services.AddTransient<GithubService>();

        var app = builder.Build();

        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", ".NET Sign-up and Verification API"));

        // global cors policy
        app.UseCors(x => x
            .SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

        // global error handler
        app.UseMiddleware<ErrorHandlerMiddleware>();

        // custom jwt auth middleware
        app.UseMiddleware<JwtMiddleware>();

        app.MapControllers();

        app.Run();
    }
}
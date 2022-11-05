using System.Text.Json.Serialization;
using TadataNet.Common.Models.Apis;

namespace WebApi.Services;

public interface IApisService
{
    Task<string> GetGithubApi();
    Task<EndpointsResponse> GetAllEndpoints();
}

public class ApisService : IApisService
{
    private readonly GithubService _githubService;

    public ApisService(GithubService githubService)
    {
        _githubService = githubService;
    }

    public Task<EndpointsResponse> GetAllEndpoints()
    {
        // todo: Get all endpoints automatically via https://stackoverflow.com/questions/70512585/how-do-i-programatically-list-all-routes-in-net-core-web-api-project

        var endpoints = new EndpointsResponse
        {
            Endpoint = new List<string> {"Links", "Tags"}
        };

        return null;
    }

    public async Task<string> GetGithubApi()
    {
        var githubBranches = await _githubService.GetAspNetCoreDocsBranchesAsync();
        string githubString = string.Empty;

        if (githubBranches is not null)
        {
            foreach (var gitHubBranch in githubBranches)
            {
                githubString += $"git: {gitHubBranch.Name}";
            }
        }

        return $"github: {githubString}";
    }
}
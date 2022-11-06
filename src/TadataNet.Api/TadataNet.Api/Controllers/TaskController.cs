using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json;
using TadataNet.Common.Authorization;
using TadataNet.Common.Models.Links;
using TadataNet.Common.Models.Tasks;
using TadataNet.Common.Services;

namespace TadataNet.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ILinksService _linksService;
    private readonly IUrlsService _urlsService;
    private readonly IApisService _apisService;

    public TaskController(ILinksService linksService, IUrlsService urlsService, IApisService apisService)
    {
        _linksService = linksService;
        _urlsService = urlsService;
        _apisService = apisService;
    }

    [AllowAnonymous]
    [HttpPost("regenerate-links")]
    [SwaggerOperation(Summary = "Reupdate links for testing", Description = "This tool will be called through WOT tool and it will delete the links and insert them again")]
    [SwaggerResponse(200, "Links updated successfully", typeof(LinkBackup))]
    public ActionResult<LinkBackup> RegenerateLinks()
    {
        // convert fom json file to type
        var json = System.IO.File.ReadAllText("Resources/backup.json");
        var links = JsonSerializer.Deserialize<List<LinkBackup>>(json);

        foreach (var link in links)
        {
            CreateLinkRequest model = new();
            model.Url = link.Url;
            model.Title = link.Title;
            model.Description = link.Description;

            _linksService.Create(model);
        }

        return Ok(links);
    }

    [AllowAnonymous]
    [HttpPost("check-links")]
    [SwaggerOperation(Summary = "Check links", Description = "This tool will check the links")]
    [SwaggerResponse(200, "Links checked successfully", typeof(void))]
    public ActionResult<string> CheckLinks()
    {
        string result = _urlsService.CheckLinks();

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("list-apis")]
    [SwaggerOperation(Summary = "List APIs", Description = "This tool will list the Github APIs")]
    [SwaggerResponse(200, "APIs listed successfully", typeof(string))]
    public async Task<ActionResult> ListApis()
    {
        string result = await _apisService.GetGithubApi();

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("backup-links")]
    [SwaggerOperation(Summary = "Backup links", Description = "This tool will backup the links with URLs")]
    [SwaggerResponse(200, "Links backed up successfully", typeof(string))]
    public ActionResult BackupLinks()
    {
        string result = _linksService.BackupLinks();

        return Ok(result);
    }
}
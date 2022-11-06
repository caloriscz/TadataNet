using Microsoft.AspNetCore.Mvc;
using TadataNet.Common.Authorization;
using TadataNet.Common.Models.Urls;
using TadataNet.Common.Services;

namespace TadataNet.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class UrlsController : ControllerBase
{
    private readonly IUrlsService _urlsService;

    public UrlsController(IUrlsService urlsService)
    {
        _urlsService = urlsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UrlsResponse>> GetAll()
    {
        var urls = _urlsService.GetAll();
        return Ok(urls);
    }

    [HttpPost]
    public ActionResult<IEnumerable<UrlsResponse>> Create(CreateUrlRequest model)
    {
        _urlsService.Create(model);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public ActionResult<IEnumerable<UrlsResponse>> Update(int id, UpdateUrlRequest model)
    {
        _urlsService.Update(id, model);
        return Ok();
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using TadataNet.Common.Authorization;
using TadataNet.Common.Controllers;
using TadataNet.Common.Models.Links;
using TadataNet.Common.Services;

namespace TadataNet.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class LinksController : BaseController
{
    private readonly ILinksService _linksService;

    public LinksController(ILinksService linksService)
    {
        _linksService = linksService;
    }

    [HttpGet]
    [EnableQuery]
    public ActionResult<IEnumerable<LinksResponse>> GetAll()
    {
        var links = _linksService.GetAll();
        return Ok(links);
    }

    [HttpPost]
    public ActionResult<IEnumerable<LinksResponse>> Create(CreateLinkRequest model)
    {
        _linksService.Create(model);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public ActionResult<IEnumerable<LinksResponse>> Update(int id, UpdateLinkRequest model)
    {
        _linksService.Update(id, model);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public ActionResult<IEnumerable<LinksResponse>> Delete(int id)
    {
        _linksService.Delete(id);
        return Ok();
    }
}
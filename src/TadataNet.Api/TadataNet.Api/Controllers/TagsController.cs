using Microsoft.AspNetCore.Mvc;
using TadataNet.Common.Authorization;
using TadataNet.Common.Entities;
using TadataNet.Common.Models.Tags;
using TadataNet.Common.Services;

namespace TadataNet.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly ITagsService _tagsService;

    public TagsController(ITagsService tagsService)
    {
        _tagsService = tagsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TagsResponse>> GetAll()
    {
        var tags = _tagsService.GetAll();
        return Ok(tags);
    }

    [HttpPost]
    public ActionResult<IEnumerable<Tag>> Create(CreateTagRequest model)
    {
        _tagsService.Create(model);
        
        return Ok(model);
    }

    [HttpPut("{id:int}")]
    public ActionResult<IEnumerable<TagsResponse>> Update(int id, UpdateTagRequest model)
    {
        _tagsService.Update(id, model);
        return Ok();
    }
}

using Microsoft.AspNetCore.Mvc;
using TadataNet.Common.Models.Settings;

namespace TadataNet.Controllers;

[Route("[controller]")]
[ApiController]
public class SettingsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<SettingsResponse>> GetAll()
    {
        return Ok();
    }

    [HttpPost]
    public ActionResult<IEnumerable<SettingsResponse>> Create(CreateSettingsResponse model)
    {
        return Ok();
    }

    [HttpPut("{id:int}")]
    public ActionResult<IEnumerable<SettingsResponse>> Update(int id, UpdateSettingsResponse model)
    {
        return Ok();
    }
}

namespace TadataNet.Common.Controllers;

using Microsoft.AspNetCore.Mvc;
using TadataNet.Common.Entities;

[Controller]
public abstract class BaseController : ControllerBase
{
    // returns the current authenticated account (null if not logged in)
    public Account Account => (Account)HttpContext.Items["Account"];

    public Link Link => (Link)HttpContext.Items["Link"];
}
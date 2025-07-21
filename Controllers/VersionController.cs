using Microsoft.AspNetCore.Mvc;
using StaticRustLauncherBackend.Models;
using StaticRustLauncherBackend.Services;

namespace StaticRustLauncherBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VersionController : ControllerBase
{
    private readonly IMockDataService _mockDataService;

    public VersionController(IMockDataService mockDataService)
    {
        _mockDataService = mockDataService;
    }

    [HttpGet]
    public ActionResult<VersionInfo> GetVersionInfo()
    {
        try
        {
            var versionInfo = _mockDataService.GetVersionInfo();
            return Ok(versionInfo);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new VersionInfo());
        }
    }

    [HttpGet("client")]
    public ActionResult<string> GetClientVersion()
    {
        try
        {
            var clientVersion = _mockDataService.GetClientVersion();
            return Ok(clientVersion);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "1.0.0");
        }
    }
} 
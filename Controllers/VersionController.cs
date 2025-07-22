using Microsoft.AspNetCore.Mvc;
using StaticRustLauncherBackend.Models;
using StaticRustLauncherBackend.Repositories;

namespace StaticRustLauncherBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VersionController : ControllerBase
{
    private readonly IVersionInfoRepository _versionInfoRepository;

    public VersionController(IVersionInfoRepository versionInfoRepository)
    {
        _versionInfoRepository = versionInfoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<VersionInfo>> GetVersionInfo()
    {
        try
        {
            var versionInfo = await _versionInfoRepository.GetVersionInfoWithSftpAsync();
            if (versionInfo == null)
            {
                return Ok(new VersionInfo());
            }
            return Ok(versionInfo);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new VersionInfo());
        }
    }

    [HttpGet("client")]
    public async Task<ActionResult<string>> GetClientVersion()
    {
        try
        {
            var clientVersion = await _versionInfoRepository.GetCurrentClientVersionAsync();
            return Ok(clientVersion);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "1.0.0");
        }
    }
} 
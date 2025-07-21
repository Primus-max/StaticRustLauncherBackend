using Microsoft.AspNetCore.Mvc;
using StaticRustLauncherBackend.Models;
using StaticRustLauncherBackend.Services;

namespace StaticRustLauncherBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServersController : ControllerBase
{
    private readonly IMockDataService _mockDataService;

    public ServersController(IMockDataService mockDataService)
    {
        _mockDataService = mockDataService;
    }

    [HttpGet]
    public ActionResult<ApiResponse<Server>> GetServers()
    {
        try
        {
            var servers = _mockDataService.GetServers();
            return Ok(new ApiResponse<Server>
            {
                Items = servers,
                Success = true
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<Server>
            {
                Items = new List<Server>(),
                Message = "Ошибка при получении серверов",
                Success = false
            });
        }
    }
} 
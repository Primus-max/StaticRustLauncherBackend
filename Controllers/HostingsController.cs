using Microsoft.AspNetCore.Mvc;
using StaticRustLauncherBackend.Models;
using StaticRustLauncherBackend.Services;

namespace StaticRustLauncherBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HostingsController : ControllerBase
{
    private readonly IMockDataService _mockDataService;

    public HostingsController(IMockDataService mockDataService)
    {
        _mockDataService = mockDataService;
    }

    [HttpGet]
    public ActionResult<ApiResponse<Hosting>> GetHostings()
    {
        try
        {
            var hostings = _mockDataService.GetHostings();
            return Ok(new ApiResponse<Hosting>
            {
                Items = hostings,
                Success = true
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<Hosting>
            {
                Items = new List<Hosting>(),
                Message = "Ошибка при получении хостингов",
                Success = false
            });
        }
    }
} 
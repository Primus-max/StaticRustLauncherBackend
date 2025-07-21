using Microsoft.AspNetCore.Mvc;
using StaticRustLauncherBackend.Models;
using StaticRustLauncherBackend.Services;

namespace StaticRustLauncherBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController : ControllerBase
{
    private readonly IMockDataService _mockDataService;

    public StatisticsController(IMockDataService mockDataService)
    {
        _mockDataService = mockDataService;
    }

    [HttpGet]
    public ActionResult<StatisticsData> GetStatistics()
    {
        try
        {
            var statistics = _mockDataService.GetStatistics();
            return Ok(statistics);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new StatisticsData
            {
                UsersOnline = 0,
                ServersCount = 0
            });
        }
    }
} 
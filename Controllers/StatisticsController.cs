using Microsoft.AspNetCore.Mvc;
using StaticRustLauncherBackend.Models;
using StaticRustLauncherBackend.Repositories;

namespace StaticRustLauncherBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticsRepository _statisticsRepository;

    public StatisticsController(IStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }

    [HttpGet]
    public async Task<ActionResult<StatisticsData>> GetStatistics()
    {
        try
        {
            var statistics = await _statisticsRepository.GetCurrentStatisticsAsync();
            if (statistics == null)
            {
                return Ok(new StatisticsData
                {
                    UsersOnline = 0,
                    ServersCount = 0
                });
            }
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
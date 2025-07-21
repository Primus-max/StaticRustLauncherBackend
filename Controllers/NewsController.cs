using Microsoft.AspNetCore.Mvc;
using StaticRustLauncherBackend.Models;
using StaticRustLauncherBackend.Services;

namespace StaticRustLauncherBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly IMockDataService _mockDataService;

    public NewsController(IMockDataService mockDataService)
    {
        _mockDataService = mockDataService;
    }

    [HttpGet]
    public ActionResult<ApiResponse<NewsItem>> GetNews()
    {
        try
        {
            var news = _mockDataService.GetNews();
            return Ok(new ApiResponse<NewsItem>
            {
                Items = news,
                Success = true
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<NewsItem>
            {
                Items = new List<NewsItem>(),
                Message = "Ошибка при получении новостей",
                Success = false
            });
        }
    }
} 
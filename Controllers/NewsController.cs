using Microsoft.AspNetCore.Mvc;
using StaticRustLauncherBackend.Models;
using StaticRustLauncherBackend.Repositories;

namespace StaticRustLauncherBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly INewsRepository _newsRepository;

    public NewsController(INewsRepository newsRepository)
    {
        _newsRepository = newsRepository;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<NewsItem>>> GetNews()
    {
        try
        {
            var news = await _newsRepository.GetAllAsync();
            return Ok(new ApiResponse<NewsItem>
            {
                Items = news.ToList(),
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

    [HttpGet("recent/{count}")]
    public async Task<ActionResult<ApiResponse<NewsItem>>> GetRecentNews(int count = 5)
    {
        try
        {
            var news = await _newsRepository.GetRecentNewsAsync(count);
            return Ok(new ApiResponse<NewsItem>
            {
                Items = news.ToList(),
                Success = true
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<NewsItem>
            {
                Items = new List<NewsItem>(),
                Message = "Ошибка при получении последних новостей",
                Success = false
            });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<NewsItem>>> GetNewsItem(int id)
    {
        try
        {
            var newsItem = await _newsRepository.GetByIdAsync(id);
            if (newsItem == null)
            {
                return NotFound(new ApiResponse<NewsItem>
                {
                    Items = new List<NewsItem>(),
                    Message = "Новость не найдена",
                    Success = false
                });
            }

            return Ok(new ApiResponse<NewsItem>
            {
                Items = new List<NewsItem> { newsItem },
                Success = true
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<NewsItem>
            {
                Items = new List<NewsItem>(),
                Message = "Ошибка при получении новости",
                Success = false
            });
        }
    }
} 
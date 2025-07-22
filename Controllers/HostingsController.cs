using Microsoft.AspNetCore.Mvc;
using StaticRustLauncherBackend.Models;
using StaticRustLauncherBackend.Repositories;

namespace StaticRustLauncherBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HostingsController : ControllerBase
{
    private readonly IHostingRepository _hostingRepository;

    public HostingsController(IHostingRepository hostingRepository)
    {
        _hostingRepository = hostingRepository;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<Hosting>>> GetHostings()
    {
        try
        {
            var hostings = await _hostingRepository.GetAllAsync();
            return Ok(new ApiResponse<Hosting>
            {
                Items = hostings.ToList(),
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

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<Hosting>>> GetHosting(int id)
    {
        try
        {
            var hosting = await _hostingRepository.GetByIdAsync(id);
            if (hosting == null)
            {
                return NotFound(new ApiResponse<Hosting>
                {
                    Items = new List<Hosting>(),
                    Message = "Хостинг не найден",
                    Success = false
                });
            }

            return Ok(new ApiResponse<Hosting>
            {
                Items = new List<Hosting> { hosting },
                Success = true
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<Hosting>
            {
                Items = new List<Hosting>(),
                Message = "Ошибка при получении хостинга",
                Success = false
            });
        }
    }
} 
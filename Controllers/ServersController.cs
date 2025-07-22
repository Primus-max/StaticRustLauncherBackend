using Microsoft.AspNetCore.Mvc;
using StaticRustLauncherBackend.Models;
using StaticRustLauncherBackend.Repositories;

namespace StaticRustLauncherBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServersController : ControllerBase
{
    private readonly IServerRepository _serverRepository;

    public ServersController(IServerRepository serverRepository)
    {
        _serverRepository = serverRepository;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<Server>>> GetServers()
    {
        try
        {
            var servers = await _serverRepository.GetServersWithUrlsAsync();
            return Ok(new ApiResponse<Server>
            {
                Items = servers.ToList(),
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

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<Server>>> GetServer(int id)
    {
        try
        {
            var server = await _serverRepository.GetServerWithUrlsAsync(id);
            if (server == null)
            {
                return NotFound(new ApiResponse<Server>
                {
                    Items = new List<Server>(),
                    Message = "Сервер не найден",
                    Success = false
                });
            }

            return Ok(new ApiResponse<Server>
            {
                Items = new List<Server> { server },
                Success = true
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse<Server>
            {
                Items = new List<Server>(),
                Message = "Ошибка при получении сервера",
                Success = false
            });
        }
    }
} 
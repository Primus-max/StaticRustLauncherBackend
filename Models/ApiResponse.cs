namespace StaticRustLauncherBackend.Models;

public class ApiResponse<T>
{
    public List<T>? Items { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; } = true;
} 
﻿namespace StaticRustLauncherBackend.Models;

public class NewsItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public string? DateCreate { get; set; }
}

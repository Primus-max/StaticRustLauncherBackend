﻿namespace StaticRustLauncherBackend.Models;

public class Hosting
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public int Users { get; set; }
    public int Projects { get; set; }
    public string? Url { get; set; }
    public int Status { get; set; }
    public HostingType HostingType => (HostingType)Status;
}

public enum HostingType
{
    OurChoice,
    Reliable
}

namespace Marrodent.ServicesDashboard.Models.Models;

public sealed class Terminal
{
    public string Address { get; set; }
    public double TotalRam { get; set; }
    public double AvailableRam { get; set; }
    public string UsedRam => $"{Math.Round((TotalRam - AvailableRam)/TotalRam * 100, 2)} %";
    public double TotalDiskSpace { get; set; }
    public double AvailableDiskSpace { get; set; }
    public string UsedDiskSpace => $"{Math.Round((TotalDiskSpace - AvailableDiskSpace) / TotalRam * 100, 2)} %";
    public string Color => AvailableRam > 1000 && Math.Round((TotalDiskSpace - AvailableDiskSpace) / TotalDiskSpace * 100, 2) > 5d  ? "#7d7d7d" : "#990000";
}
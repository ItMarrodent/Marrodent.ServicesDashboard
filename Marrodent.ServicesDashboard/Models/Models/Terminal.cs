namespace Marrodent.ServicesDashboard.Models.Models;

public sealed class Terminal
{
    public string Address { get; set; }
    public double TotalRam { get; set; }
    public double AvailableRam { get; set; }
    public string UsedRam => $"{Math.Round((TotalRam - AvailableRam)/TotalRam * 100, 2)} %";
    public string Color => AvailableRam > 1000 ? "#7d7d7d" : "#990000";
}
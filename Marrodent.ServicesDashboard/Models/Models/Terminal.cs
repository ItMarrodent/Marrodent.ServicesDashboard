using System.Text.Json.Serialization;

namespace Marrodent.ServicesDashboard.Models.Models;

public sealed class Terminal
{
    public string Address { get; set; }
    public string TotalRam { get; set; }
    public string AvailableRam { get; set; }
}
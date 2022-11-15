namespace Marrodent.ServicesDashboard.Models.Models;

public class IISWebsites
{
    public List<IISWebsite> websites { get; set; }
}
public class IISWebsite
{
    public string name { get; set; }
    public string id { get; set; }
    public string status { get; set; }
}


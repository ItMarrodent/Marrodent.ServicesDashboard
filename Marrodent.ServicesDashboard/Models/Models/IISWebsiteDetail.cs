namespace Marrodent.ServicesDashboard.Models.Models;

public class IISWebsiteDetail
{
    public string name { get; set; }
    public string id { get; set; }
    public string physical_path { get; set; }
    public int key { get; set; }
    public string status { get; set; }
    public bool server_auto_start { get; set; }
    public string enabled_protocols { get; set; }
    public Limits limits { get; set; }
    public List<Binding> bindings { get; set; }
    public ApplicationPool application_pool { get; set; }
}

public class ApplicationPool
{
    public string name { get; set; }
    public string id { get; set; }
    public string status { get; set; }
}

public class Binding
{
    public string protocol { get; set; }
    public string binding_information { get; set; }
    public string ip_address { get; set; }
    public int port { get; set; }
    public string hostname { get; set; }
}

public class Limits
{
    public int connection_timeout { get; set; }
    public long max_bandwidth { get; set; }
    public long max_connections { get; set; }
    public int max_url_segments { get; set; }
}


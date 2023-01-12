namespace Marrodent.ServicesDashboard.Models.Models
{
    public sealed class IISConfigs
    {
        public IISConfigItem[] Configs { get; set; }
    }

    public sealed class IISConfigItem
    {
        public string Token { get; set; }
        public string Login { get; set; }
        public string Domain { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
    }
}

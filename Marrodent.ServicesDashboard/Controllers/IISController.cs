using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Enum;
using Marrodent.ServicesDashboard.Models.Models;
using Microsoft.Extensions.Options;
using RestSharp;

namespace Marrodent.ServicesDashboard.Controllers;

public sealed class IISController : IServiceController
{
    //Private
    private readonly IISConfig _config;
    private readonly RestClient _client;
    
    //CTOR
    public IISController(IOptions<IISConfig> options)
    {
        _config = options.Value;
        _client = new RestClient($"https://{_config.Address}:{_config.Port}");
    }
    
    //Public
    public ServiceState GetState(string websiteName)
    {
        return ServiceState.Running;
    }
}
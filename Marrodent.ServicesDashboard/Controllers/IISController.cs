using System.Net;
using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Enum;
using Marrodent.ServicesDashboard.Models.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace Marrodent.ServicesDashboard.Controllers;

public sealed class IISController : IWebServiceController
{
    //Private
    private readonly IISConfig _config;
    private readonly RestClient _client;
    private ICollection<IISWebsite> _websites;

    //CTOR
    public IISController(IOptions<IISConfig> options)
    {
        _config = options.Value;
        _client = new RestClient($"https://{_config.Address}:{_config.Port}")
        {
            Authenticator = new NtlmAuthenticator(new NetworkCredential(_config.Login, _config.Password, _config.Domain)),
            RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
        };
        _client.AddDefaultHeader("Access-Token", $"Bearer {_config.Token}");
    }
    
    //Public
    public async Task Refresh()
    {
        var response  = await _client.ExecuteAsync( new RestRequest("api/webserver/websites"));
        _websites = JsonConvert.DeserializeObject<IISWebsites>(response.Content).websites;
    }
    
    public async Task<ServiceState> GetState(string websiteName)
    {
        var website = _websites.FirstOrDefault(x => x.name == websiteName);

        return website.status switch
        {
            "started" => ServiceState.Running,
            "stopped" => ServiceState.Stopped,
            _ => ServiceState.Unknown
        };
    }

    public async Task Start(string websiteName)
    {
        var website = await GetWebsite(websiteName);
        website.status = "started";
        SetWebsite(website);
    }

    public async Task Stop(string websiteName)
    {
        var website = await GetWebsite(websiteName);
        website.status = "stopped";
        SetWebsite(website);
    }
    
    //Private
    private async Task SetWebsite(IISWebsiteDetail website)
    {
        var request = new RestRequest($"api/webserver/websites/{website.id}", Method.PATCH);
        request.AddJsonBody(JsonConvert.SerializeObject(website));
        await _client.ExecuteAsync(request);
    }
    
    private async Task<IISWebsiteDetail> GetWebsite(string websiteName)
    {
        IISWebsite website = _websites.First(x => x.name == websiteName);
        var response  = await _client.ExecuteAsync( new RestRequest($"api/webserver/websites/{website.id}"));
        return JsonConvert.DeserializeObject<IISWebsiteDetail>(response.Content);
    }
}
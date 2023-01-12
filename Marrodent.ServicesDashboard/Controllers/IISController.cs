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
    private List<IISWebsite> _websites;
    private Dictionary<string, RestClient> _clients;

    //CTOR
    public IISController(IOptions<IISConfigs> options)
    {
        _clients = new Dictionary<string, RestClient>();

        foreach (IISConfigItem item in options.Value.Configs)
        {
            RestClient client = new RestClient($"https://{item.Address}:{item.Port}")
            {
                Authenticator =
                    new NtlmAuthenticator(new NetworkCredential(item.Login, item.Password, item.Domain)),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            };

            client.AddDefaultHeader("Access-Token", $"Bearer {item.Token}");
            _clients.Add(item.Address, client);
        }
    }

    //Public
    public async Task Refresh()
    {
        _websites = new List<IISWebsite>();

        foreach (RestClient client in _clients.Values)
        {
            var response = await client.ExecuteAsync(new RestRequest("api/webserver/websites"));
            _websites.AddRange(JsonConvert.DeserializeObject<IISWebsites>(response.Content).websites);
        }
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

    public async Task Start(string address, string websiteName)
    {
        var website = await GetWebsite(address, websiteName);
        website.status = "started";
        await SetWebsite(address, website);
    }

    public async Task Stop(string address, string websiteName)
    {
        var website = await GetWebsite(address, websiteName);
        website.status = "stopped";
        await SetWebsite(address, website);
    }

    //Private
    private async Task SetWebsite(string address, IISWebsiteDetail website)
    {
        var request = new RestRequest($"api/webserver/websites/{website.id}", Method.PATCH);
        request.AddJsonBody(JsonConvert.SerializeObject(website));
        await _clients[address].ExecuteAsync(request);
    }

    private async Task<IISWebsiteDetail> GetWebsite(string address, string websiteName)
    {
        IISWebsite website = _websites.First(x => x.name == websiteName);
        var response = await _clients[address].ExecuteAsync(new RestRequest($"api/webserver/websites/{website.id}"));
        return JsonConvert.DeserializeObject<IISWebsiteDetail>(response.Content);
    }
}
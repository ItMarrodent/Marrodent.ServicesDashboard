﻿using System.Net;
using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Enum;
using Marrodent.ServicesDashboard.Models.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace Marrodent.ServicesDashboard.Controllers;

public sealed class IISController : IServiceController
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
    }
    
    //Public
    public async Task Refresh()
    {
        var request = new RestRequest("api/webserver/websites");
        request.AddHeader("Access-Token", $"Bearer {_config.Token}");
        var response  = await _client.ExecuteAsync(request);
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
}
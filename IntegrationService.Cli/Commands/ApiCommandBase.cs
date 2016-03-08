﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Khaale.TechTalks.AwesomeLibs.Shared.ServiceDiscovery;
using ManyConsole;

namespace Khaale.TechTalks.AwesomeLibs.IntegrationService.Cli.Commands
{
    public abstract class ApiCommandBase : ConsoleCommand
    {
        protected abstract Task<HttpResponseMessage> ExecuteCommand(HttpClient client);

        public override int Run(string[] remainingArguments)
        {
            var serviceLookup = new ServiceLookupWithFallback(
                new ServiceLookup("dev"), 
                new ServiceLookupFromAppConfig());

            var address = serviceLookup.GetServiceUri("IntegrationService");

            var httpClient = new HttpClient();
            httpClient.BaseAddress = address;

            var result = ExecuteCommand(httpClient).Result;

            result.EnsureSuccessStatusCode();

            Console.WriteLine(result.Content.ReadAsStringAsync().Result);

            return 0;
        }
    }
}
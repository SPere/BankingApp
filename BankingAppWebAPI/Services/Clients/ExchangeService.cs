using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BankingAppWebAPI.Models;
using BankingAppWebAPI.Services.Clients.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BankingAppWebAPI.Services.Clients
{
    public class ExchangeService : IExchangeService
    {
        private readonly IConfiguration _configuration;

        public ExchangeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ExchangeRates> GetExchangeRatesForEuro()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(_configuration.GetSection("ExchangeUri").Value)
            };

            var response = await client.GetAsync("");

            response.EnsureSuccessStatusCode();
            
            var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ExchangeRates>(
                responseStream,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

    }
}

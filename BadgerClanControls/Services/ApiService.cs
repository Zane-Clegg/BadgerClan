using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgerClanControls.Services
{
    internal class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("GameControllerApi");
        }
        public async Task SetApiAsync(string pathing)
        {
            var url = $"https://localhost:7222/set/{pathing}";
            var response = await _httpClient.GetAsync(url);
        }
    }
}

using BadgerClanControls.Models;
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
        public async Task<ResultPattern<bool,string>> SetApiAsync(string apiUrl, string pathing)
        {
            var url = $"{apiUrl}/{pathing}";
            if (apiUrl == null)
            {
                return ResultPattern<bool, string>.Fail("Null url");
            }
            try
            {
                var response = await _httpClient.GetAsync(url);

                // branchless option
                //return ResultPattern<bool, string>.Ok(response.IsSuccessStatusCode)
                //    ?? ResultPattern<bool, string>.Fail($"Api request failed with error: {response.StatusCode}");

                if (response.IsSuccessStatusCode) 
                {
                    return ResultPattern<bool, string>.Ok(true);
                }
                return ResultPattern<bool, string>.Fail($"Api request failed with error: {response.StatusCode}");
            }
            catch (Exception ex) 
            {
                return ResultPattern<bool,string>.Fail($"{ex.Message}\nCheck your input and try again");
            }
        }
    }
}

using LarsTravel.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LarsTravelClient.Service
{
    public class CityService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public CityService(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }
        string domain = "https://localhost:44348/";
        public async Task<List<City>> getAllCity()
        {
            string url = domain + "api/City";
            List<City> cities = new List<City>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    cities = JsonConvert.DeserializeObject<List<City>>(result);
                    return cities;
                }
                return cities;
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return cities;
            }
        }
    }
}

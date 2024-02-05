using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV1.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ClientConvertisseurV1.Services
{
    internal class WSService : IService
    {
        private readonly HttpClient client;
        public WSService(string url)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url); // https://localhost:7281/api
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }

        public async Task<List<Devise>> GetDevisesAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

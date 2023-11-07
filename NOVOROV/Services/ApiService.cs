using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using NOVOROV.Models;
using NOVOROV.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace NOVOROV.Services
{
    public class ApiService : IApiService
    {
        public async Task<ApiAuthResponse> GetApiAuthToken()
        {
            string url = "https://maestro.vivo.com.br/gacesso/autenticar";
            HttpClient client = new HttpClient();
            //var requestData = new { idsistema = 2, usuario = "TBR00812", senha = "USER@R0v2024" };
            var requestData = new { idsistema = 2, usuario = "A0108050", senha = "Gui@@2049" };
            string json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonConvert.DeserializeObject<ApiAuthResponse>(responseContent);
            return jsonResponse;
        }

        public async Task<ApiResponse> GetApiData(string token)
        {
            string url = "https://maestro.vivo.com.br/sginfra/api/prisma/rov";
            HttpClient client = new();
            client.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Bearer", token);
            var query = new Dictionary<string, string?>()
            {
                ["data_inicio"] = "2023-04-01",
                ["linhas"] = "10",
                ["pagina"] = "0"
            };
            var uri = QueryHelpers.AddQueryString(url, query);
            var response = await client.GetAsync(uri);
            string responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonConvert.DeserializeObject<ApiResponse>(responseContent);
            return jsonResponse;
        }
    }
}

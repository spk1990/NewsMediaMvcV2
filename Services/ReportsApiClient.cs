using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NewsMediaMvc.Data;
using System.Net.Http.Json;
using NewsMediaMvc.Models;
using Reports.Models;


namespace NewsMediaMvc.Services
{
    public class ReportsApiClient
    {
        public HttpClient Client {get; set;}

        public ReportsApiClient(HttpClient client) {

            client.BaseAddress = new System.Uri("https://localhost:7240");

            client.DefaultRequestHeaders.Add("Accept", "application.json");

            Client = client;
        }

        public async Task<IEnumerable<Report>> GetReportsList()
        {
            return await Client.GetFromJsonAsync<IEnumerable<Report>>("/api/Report");
        }
    }
}
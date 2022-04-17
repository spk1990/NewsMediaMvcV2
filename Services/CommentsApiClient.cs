using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NewsMediaMvc.Data;
using System.Net.Http.Json;
using NewsMediaMvc.Models;
using Reports.Models;
using Comments.Models;


namespace NewsMediaMvc.Services
{
    public class CommentsApiClient
    {
        public HttpClient Client {get; set;}

        public CommentsApiClient(HttpClient client) {

            client.BaseAddress = new System.Uri("https://localhost:7033");

            client.DefaultRequestHeaders.Add("Accept", "application.json");

            Client = client;
        }

        public async Task<IEnumerable<Comment>> GetCommentsList()
        {
            return await Client.GetFromJsonAsync<IEnumerable<Comment>>("/api/Comment");
        }
    }
}
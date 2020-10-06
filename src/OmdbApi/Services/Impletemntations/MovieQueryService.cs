using OmdbApi.Models.Model;
using OmdbApi.Services.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace OmdbApi.Services.Impletemntations
{
    public class MovieQueryService : IMovieQueryService
    {
        private HttpClient _httpClient;
        private const string API  = "8e196a2f";
        public MovieQueryService()
        {
            _httpClient = new HttpClient();
        }
        
        public async Task<MovieFullIformation> GetFullMovieInformation(string id= "tt0290000")
        {
            var json = await this.Request($"i={id}");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<MovieFullIformation>(json);
        }

        public async Task<SearchResult> GetMoviesByTitleAndPage(string title, uint page = 1)
        {
            var json  = await this.Request($"&page={page}&s={title}");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SearchResult>(json);
        }

        private async Task<string> Request(string request )
        {
            var json = await _httpClient.GetStringAsync($"http://www.omdbapi.com/?apikey={API}&{request}");
            return json;
        }
       
        

    }
}

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
        
        public MovieFullIformation GetFullMovieInformation(string id= "tt0290000")
        {
            var json = this.Request($"i={id}");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<MovieFullIformation>(json.Result);
        }

        public SearchResult GetMoviesByTitleAndPage(string title, int page = 1)
        {
            var json  = this.Request($"&page={page}&s={title}");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<SearchResult>(json.Result);
        }

        private async Task<string> Request(string request )
        {
            var json = await _httpClient.GetStringAsync($"http://www.omdbapi.com/?apikey={API}&{request}");
            return json;
        }
       
        

    }
}

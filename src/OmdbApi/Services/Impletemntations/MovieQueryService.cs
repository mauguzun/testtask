using OmdbApi.Models.Model;
using OmdbApi.Services.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace OmdbApi.Services.Impletemntations
{
    public class MovieQueryService : IMovieQueryService
    {
        private HttpClient _httpClient;
        private const string API  = "8e196a2f"; // moved to keys sections 
        public MovieQueryService()
        {
            _httpClient = new HttpClient();
        }
        
        public async Task<MovieFullIformation> GetFullMovieInformation(string id )
        {
            var json = await this.Request($"i={id}");
            return json != null ?  Newtonsoft.Json.JsonConvert.DeserializeObject<MovieFullIformation>(json): null; ;
        }

        public async Task<SearchResult> GetMoviesByTitleAndPage(string title, uint page = 1)
        {
            var json  = await this.Request($"&page={page}&s={title}");
            return json != null ? Newtonsoft.Json.JsonConvert.DeserializeObject<SearchResult>(json) : null;
        }

        private async Task<string> Request(string request )
        {
            var responce = await _httpClient.GetAsync($"http://www.omdbapi.com/?apikey={API}&{request}");
            return (responce.StatusCode == System.Net.HttpStatusCode.OK) ? await responce.Content.ReadAsStringAsync() : null;
        }
       
        

    }
}

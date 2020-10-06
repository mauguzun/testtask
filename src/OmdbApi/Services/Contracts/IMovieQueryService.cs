using OmdbApi.Models.Model;

namespace OmdbApi.Services.Contracts
{
    public interface IMovieQueryService
    {
        SearchResult GetMoviesByTitleAndPage(string title,int page = 1);

        MovieFullIformation GetFullMovieInformation(string id); 
    }
}

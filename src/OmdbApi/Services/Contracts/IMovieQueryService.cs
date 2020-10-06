using OmdbApi.Models.Model;
using System.Threading.Tasks;

namespace OmdbApi.Services.Contracts
{
    public interface IMovieQueryService
    {
        Task<SearchResult> GetMoviesByTitleAndPage(string title, uint page = 1);
        Task<MovieFullIformation> GetFullMovieInformation(string id);
    }
}

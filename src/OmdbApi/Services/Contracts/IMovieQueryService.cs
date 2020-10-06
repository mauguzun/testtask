using OmdbApi.Models.Model;
using System.Threading.Tasks;

namespace OmdbApi.Services.Contracts
{
    public interface IMovieQueryService
    {
        Task<SearchResult> GetMoviesByTitleAndPage(string title, uint page );
        Task<MovieFullIformation> GetFullMovieInformation(string id);
    }
}

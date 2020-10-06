using OmdbApi.Models.Model;
using System.Collections.Generic;

namespace OmdbApi.Models.ModelView
{
    public class MovieSeachResult
    {
        public IEnumerable<Movie> Search { get; set; }
        public int NextPage { get; set; } = 0;
    }
}

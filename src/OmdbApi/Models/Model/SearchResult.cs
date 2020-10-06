using System.Collections.Generic;

namespace OmdbApi.Models.Model
{
    public class SearchResult
    {
        public bool Response { get; set; }
        public int TotalResults { get; set; }
        public IEnumerable <Movie> Search { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OmdbApi.Models.ModelView;
using OmdbApi.Services.Contracts;

namespace OmdbApi.Controllers
{
    [ApiController]
    [Route("search")]
    public class SearchController : ControllerBase
    {

        private readonly ILogger<SearchController> _logger;

        private readonly IMovieQueryService _movieQueryService;

        private const int PAGE_SIZE = 10;

        public SearchController(
            ILogger<SearchController> logger,
            IMovieQueryService movieQueryService
            )
        {
            _logger = logger;
            _movieQueryService = movieQueryService;
            _movieQueryService = movieQueryService;
        }

        [HttpGet("{title}/{page}")]
        public string SearchMovies(string title, int page)
        {
            var query = _movieQueryService.GetMoviesByTitleAndPage(title, page);
            int nextPage = (query?.TotalResults > page * PAGE_SIZE) ? ++page : 0;
            return Newtonsoft.Json.JsonConvert.SerializeObject(new MovieSeachResult { Search = query.Search, NextPage = nextPage });
        }
    }
}

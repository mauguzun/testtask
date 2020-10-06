using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OmdbApi.Models.Model;
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

        private readonly IDataService _dataService;

        private const int PAGE_SIZE = 10;

        public SearchController(
            ILogger<SearchController> logger,
            IMovieQueryService movieQueryService,
            IDataService dataService
            )
        {
            _logger = logger;
            _movieQueryService = movieQueryService;
            _dataService = dataService;
        }

        [HttpGet("{title}/{page}")]
        public async Task<IActionResult> SearchMovies(string title, uint page)
        {
            var query = await _movieQueryService.GetMoviesByTitleAndPage(title, page);
            uint nextPage = (query?.TotalResults > page * PAGE_SIZE) ? ++page : 0;
            var last = _dataService.GetLastQueries();

            _dataService.SaveQuery(new QuerySearch { Query = title });

            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(new MovieSeachResult { LastSearch = last ,   Search = query.Search, NextPage = nextPage }));
        }
    }
}

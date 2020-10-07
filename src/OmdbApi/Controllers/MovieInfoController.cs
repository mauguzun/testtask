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
    [Route("/")] 
    //[Route("/")]  appologies here must be route movie ,but i dont`t want build angular one more time
    public class MovieInfoController : ControllerBase
    {

        private readonly ILogger<MovieInfoController> _logger;

        private readonly IMovieQueryService _movieQueryService;

        private readonly IDataService _dataService;

        private const int PAGE_SIZE = 10;

        public MovieInfoController(
            ILogger<MovieInfoController> logger,
            IMovieQueryService movieQueryService,
            IDataService dataService
            )
        {
            _logger = logger;
            _movieQueryService = movieQueryService;
            _dataService = dataService;
        }

        [HttpGet("{imbdId}")]
        public async Task<IActionResult> MovieInfo(string imbdId)
        {
            var query = await _movieQueryService.GetFullMovieInformation(imbdId);
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(query));
        }

        [HttpGet("search/{title}/{page}")]
        public async Task<IActionResult> SearchMovies(string title, uint page)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                _dataService.SaveQuery(new QuerySearch { Query = title, Page = page });
            }

            var query = await _movieQueryService.GetMoviesByTitleAndPage(title, page);
            uint nextPage = (query?.TotalResults > page * PAGE_SIZE) ? ++page : 1;
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(new MovieSeachResult { Search = query?.Search, NextPage = nextPage }));
        }
    }
}

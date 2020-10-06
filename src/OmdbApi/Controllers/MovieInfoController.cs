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
    [Route("movie")]
    public class MovieInfoController : ControllerBase
    {

        private readonly ILogger<MovieInfoController> _logger;

        private readonly IMovieQueryService _movieQueryService;


        public MovieInfoController(
            ILogger<MovieInfoController> logger,
            IMovieQueryService movieQueryService
            )
        {
            _logger = logger;
            _movieQueryService = movieQueryService;
            _movieQueryService = movieQueryService;
        }

        [HttpGet("{imbdId}")]
        public string MovieInfo(string imbdId)
        {
            var query = _movieQueryService.GetFullMovieInformation(imbdId);
            return Newtonsoft.Json.JsonConvert.SerializeObject(query);
        }
    }
}

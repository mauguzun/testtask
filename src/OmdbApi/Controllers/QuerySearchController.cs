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
    [Route("queries")]
    public class QuerySearchController : ControllerBase
    {

        private readonly ILogger<QuerySearchController> _logger;

        private readonly IDataService _dataService;


        public QuerySearchController(
            ILogger<QuerySearchController> logger,
            IDataService dataService
            )
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var last = _dataService.GetLastQueries();
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(last));
        }
    }
}

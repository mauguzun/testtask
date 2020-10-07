using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using OmdbApi.Controllers;
using OmdbApi.Models.Model;
using OmdbApi.Models.ModelView;
using OmdbApi.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackTests
{
    public class MovieInfoControllerTests
    {


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCaseSource("_testCases")]
        public void ValidData_SearchMovies_ReturnJson(string movieName, uint page, SearchResult searchResult)
        {
            //Arange
            var logger = new Mock<ILogger<MovieInfoController>>();
            var moviequery = new Mock<IMovieQueryService>();
            var dataservice = new Mock<IDataService>();

            moviequery.Setup(x => x.GetMoviesByTitleAndPage(movieName, page)).ReturnsAsync(searchResult);
            dataservice.Setup(x => x.SaveQuery(new QuerySearch() { Page = page, Query = movieName }));
            var target = new MovieInfoController(logger.Object, moviequery.Object, dataservice.Object);
           
            // Act
            var result = target.SearchMovies(movieName, page);
            var json = ((OkObjectResult) result.Result).Value ;
            
            // Assert
            moviequery.Verify(x => x.GetMoviesByTitleAndPage(movieName, page), Times.Once);
            dataservice.Verify(x => x.SaveQuery(It.IsAny<QuerySearch>()), Times.Once);
            Assert.AreEqual(json, Newtonsoft.Json.JsonConvert.SerializeObject(new MovieSeachResult { Search = searchResult?.Search, NextPage = ++page }));

        }

        [Test]
        [TestCaseSource("_testCasesMovie")]
        public void ValidData_MovieInfo_ReturnJson(string movieId, MovieFullIformation movie)
        {
            //Arange
            var logger = new Mock<ILogger<MovieInfoController>>();
            var moviequery = new Mock<IMovieQueryService>();
            var dataservice = new Mock<IDataService>();

            moviequery.Setup(x => x.GetFullMovieInformation(movieId)).ReturnsAsync(movie);
            var target = new MovieInfoController(logger.Object, moviequery.Object, dataservice.Object);

            // Act
            var result = target.MovieInfo(movieId);
            var json = ((OkObjectResult)result.Result).Value;

            // Assert
            moviequery.Verify(x => x.GetFullMovieInformation(movieId), Times.Once);
            Assert.AreEqual(json, Newtonsoft.Json.JsonConvert.SerializeObject(movie));

        }

        private static readonly object[] _testCases =
        {
             new object[]
             {
                "mat",
                1U,
                 new SearchResult()
                 {
                     Search = new List<Movie>()
                     {  new Movie()
                        {
                         ImdbID = "tt0841929",
                         Year = "1992",
                         Poster = "https://previews.123rf.com/images/dezydezy/dezydezy1707/dezydezy170700123/82029093-lol-meme-illustration-lol-face-lots-of-laugh.jpg"
                        }
                     },
                     Response = true ,
                     TotalResults = 123
                 }
                 
             },
        };
        private static readonly object[] _testCasesMovie =
        {
             new object[]
             {
                "tt0841929",
                 new MovieFullIformation()
                 {
                     ImdbID = "tt0841929"
                 }
                 
             },
        };

    }

}
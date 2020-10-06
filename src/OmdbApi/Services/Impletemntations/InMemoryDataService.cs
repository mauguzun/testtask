using Microsoft.EntityFrameworkCore;
using OmdbApi.Models;
using OmdbApi.Models.Model;
using OmdbApi.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmdbApi.Services.Impletemntations
{
    public class InMemoryDataService : IDataService
    {
        private readonly DataContext _dbContext;

        public InMemoryDataService()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "Test").Options;
            _dbContext = new DataContext(options);
        }
        public IEnumerable<QuerySearch> GetLastQueries(int count = 5)
        {
            return _dbContext.QuerySearchs.OrderByDescending(x => x.DateTime).Take(count);
        }
        public void SaveQuery(QuerySearch query)
        {
            _dbContext.Add(query);
            _dbContext.SaveChangesAsync();
        }
    }
}

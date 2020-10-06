using OmdbApi.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmdbApi.Services.Contracts
{
    public interface IDataService
    {
        public IEnumerable<QuerySearch> GetLastQueries(int count = 5);
        public void SaveQuery(QuerySearch query);
    }
}

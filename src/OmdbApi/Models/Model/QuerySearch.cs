using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmdbApi.Models.Model
{
    public class QuerySearch
    {
        public int Id { get; set; }
        public string Query { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}

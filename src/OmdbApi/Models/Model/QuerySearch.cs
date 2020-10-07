using System;

namespace OmdbApi.Models.Model
{
    public class QuerySearch
    {
        public int Id { get; set; }
        public string Query { get; set; }
        public uint Page { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}

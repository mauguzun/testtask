using Microsoft.EntityFrameworkCore;
using OmdbApi.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmdbApi.Models
{
    public class DataContext : DbContext
    {
        public DbSet<QuerySearch> QuerySearchs { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

    }
}

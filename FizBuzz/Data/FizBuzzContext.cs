using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FizBuzz.Models;

namespace FizBuzz.Data
{
    public class FizBuzzContext : DbContext
    {
        public FizBuzzContext (DbContextOptions<FizBuzzContext> options)
            : base(options)
        {
        }

        public DbSet<FizBuzz.Models.NumTable> NumTable { get; set; }
    }
}

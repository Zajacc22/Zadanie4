using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zad3.Models;


namespace Zad3.Data
{
    public class NumberContext : DbContext
    {
        public NumberContext(DbContextOptions options) : base(options) { }
        public DbSet<Numbers> Numbers { get; set; }
    }
}

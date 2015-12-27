using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace lesson18_4_finish.Models
{
    public class CompContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
    }
}
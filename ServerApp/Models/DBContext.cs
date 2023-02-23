using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}

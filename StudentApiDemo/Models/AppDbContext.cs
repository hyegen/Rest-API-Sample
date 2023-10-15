using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StudentApiDemo.Managers;


namespace StudentApiDemo.Models
{
    public class AppDbContext: DbContext
    {
        ConnectionStringManager connectionStringManager = new ConnectionStringManager();
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var constr = connectionStringManager.GetConnectionString();
            optionsBuilder.UseSqlServer(constr);
        }

        public DbSet<Student> Students { get; set; }
    }
}

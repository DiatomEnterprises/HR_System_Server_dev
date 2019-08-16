using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Server.Configuration;
using HR_Server.Model;
using Microsoft.EntityFrameworkCore;

namespace HR_Server.Contexts
{
    public class HrDbContext : DbContext
    {
        //StorageConfiguration _storeConfig;

        //public HrDbContext()
        //{
        //}

        public HrDbContext(DbContextOptions<HrDbContext> options)
            : base(options)
        {            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(//"Server=(localdb)\\MSSQLLocalDB;Database=HRSystem;Trusted_Connection=True;");
        //        _storeConfig.Database);
        //}

        public DbSet<Person> Person { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=CustomerDB;");
        //}
        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<Person>().HasKey(new[] {"PersonId"});
        //    }
    }
}
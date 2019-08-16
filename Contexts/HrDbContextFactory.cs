using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HR_Server.Contexts
{
    public class HrDbContextFactory : IDesignTimeDbContextFactory<HrDbContext>
    {
        public HrDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HrDbContext>();
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = HRSystem; Trusted_Connection = True;");

            return new HrDbContext(optionsBuilder.Options);
        }
    }
}
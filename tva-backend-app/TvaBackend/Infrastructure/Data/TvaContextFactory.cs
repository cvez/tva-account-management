using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class  TvaContextFactory  : IDesignTimeDbContextFactory<TvaContext>
    {
        public TvaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TvaContext>();

            // Configure the context to use SQL Server
            optionsBuilder.UseSqlServer("Server=PONY\\MSSQLSERVER01; Database=VirtualAgentDB;Trusted_Connection=true;Encrypt=False;");

            return new TvaContext(optionsBuilder.Options);
        }
    }
}
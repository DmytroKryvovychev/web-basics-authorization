using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using web_basics.data.Entities;

namespace web_basics.data
{
    public class WebBasicsDBContext : DbContext
    {
        IConfiguration _configuration;

        public WebBasicsDBContext(IConfiguration configuration) : base()
        {
            this._configuration = configuration;
            DbInitializer.Initialize(this);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_styme.Entities;

namespace teste_styme.Data
{
    public class TesteStymeContext : DbContext
    {
        public TesteStymeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurantes { get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Restaurant>().HasKey(_ => _.RestaurantId);
            base.OnModelCreating(builder);
            builder.Entity<Menu>().HasKey(_ => _.MenuId);
            base.OnModelCreating(builder);

        }
    }
}

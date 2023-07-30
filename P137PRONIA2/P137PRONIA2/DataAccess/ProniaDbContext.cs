using System;
using Microsoft.EntityFrameworkCore;
using P137PRONIA2.Models;

namespace P137PRONIA2.DataAccess
{
    namespace P137Pronia.DataAccess
    {
        public class ProniaDbContext : DbContext
        {
            public ProniaDbContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<Slider> Sliders { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<ProductImage> ProductImages { get; set; }
        }
    }
}


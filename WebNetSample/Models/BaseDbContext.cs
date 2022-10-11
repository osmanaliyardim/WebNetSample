using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebNetSample.Models.Entities;

namespace WebNetSample.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public BaseDbContext()
        {

        }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
               base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("WebNetSampleConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Generally, complex softwares include different namings in DB,
            // so that we have to indicate these rows here explicitly
            // otherwise, it might cause many conflicts in our DB.
            modelBuilder.Entity<Category>(a =>
            {
                a.ToTable("Categories").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

                // A category can contain more than one products.
                a.HasMany(p => p.Products);
            });

            modelBuilder.Entity<Product>(a =>
            {
                a.ToTable("Products").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.CategoryId).HasColumnName("CategoryId");
                a.Property(p => p.SupplierId).HasColumnName("SupplierId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Price).HasColumnName("Price");
                a.Property(p => p.ImageUrl).HasColumnName("ImageUrl");

                // A product can contain more than one categories and suppliers.
                a.HasMany(p => p.Categories);
                a.HasMany(p => p.Suppliers);
            });

            modelBuilder.Entity<Supplier>(a =>
            {
                a.ToTable("Suppliers").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

                //  A supplier can contain more than one products.
                a.HasMany(p => p.Products);
            });

            // Seed data for product CATEGORIES
            //Category[] categoryEntitySeeds = { new(1, "Toy"), new(2, "Food") };
            //modelBuilder.Entity<Category>().HasData(categoryEntitySeeds);

            // Seed data for PRODUCTS
            //Product[] productEntitySeeds =
            //{
            //    new(1, 1, 1, "Duck", 20, ""),
            //    new(1, 2, 2, "Biscuit", 3, "")
            //};
            //modelBuilder.Entity<Product>().HasData(productEntitySeeds);

            // Seed data for product SUPPLIERS
            //Supplier[] supplierEntitySeeds = { new(1, "Toyz Toyz Shop"), new(2, "Ülker") };
            //modelBuilder.Entity<Supplier>().HasData(supplierEntitySeeds);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebNetSample.Entity.Concrete;

namespace WebNetSample.DataAccess.Concrete.EntityFramework.Contexts;

public class WebNetSampleDBContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    public WebNetSampleDBContext()
    {

    }

    public WebNetSampleDBContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //        base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("WebNetSampleConnectionString")));
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //var conStr = Configuration.GetConnectionString("WebNetSampleConnectionString");
        optionsBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-5JKESUF\SQLEXPRESS;Database=WebNetSampleDB;Trusted_Connection=true");
        //optionsBuilder.UseSqlServer(connectionString: Configuration.GetConnectionString("WebNetSampleConnectionString"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebNetSampleDBContext).Assembly);
    }
}
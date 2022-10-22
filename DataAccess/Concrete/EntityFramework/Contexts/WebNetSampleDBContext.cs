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

    public WebNetSampleDBContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebNetSampleDBContext).Assembly);
    }
}
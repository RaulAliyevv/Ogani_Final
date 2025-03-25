using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ogani.Core.Entities;
using Ogani.DataAccess.Interceptors;

namespace Ogani.DataAccess.Context;

public class AppDbContext : IdentityDbContext<AppUser>
{
    private readonly BaseAuditableInterceptor _baseAuditableInterceptor;

    public AppDbContext(DbContextOptions options, BaseAuditableInterceptor baseAuditableInterceptor) : base(options)
    {
        _baseAuditableInterceptor = baseAuditableInterceptor;
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_baseAuditableInterceptor);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);
    }

}

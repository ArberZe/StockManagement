using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Common;
using StockManagement.Domain.Entities;

namespace StockManagement.Persistence;

public class StockManagementDbContext: DbContext
{
    public StockManagementDbContext(DbContextOptions<StockManagementDbContext> options): base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockManagementDbContext).Assembly);
        
        //seed data added through migrations
        var foodGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
        var drinkGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
        //var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
        //var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");
        
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 1,
            Name = "Ushqim"
        });
        
        modelBuilder.Entity<Category>().HasData(new Category
        {
            CategoryId = 2,
            Name = "Pije"
        });
        
        modelBuilder.Entity<Product>().HasData(new Product()
        {
            ProductId = 1,
            Name = "Red Bull",
            Description = "Pije energjike",
            SellingPrice = 1.50m,
            CategoryId = 2
        });
        
        modelBuilder.Entity<Product>().HasData(new Product()
        {
            ProductId = 2,
            Name = "Coca Cola",
            Description = "Pije freskuese",
            SellingPrice = 0.70m,
            CategoryId = 2
        });
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }


}
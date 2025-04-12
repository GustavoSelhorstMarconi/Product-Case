using Microsoft.EntityFrameworkCore;

namespace Product.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Domain.Entities.ProductEntity> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.ProductEntity>()
                .Property(x => x.Title).HasColumnType("varchar(100)");

            modelBuilder.Entity<Domain.Entities.ProductEntity>()
                .Property(x => x.Description).HasColumnType("varchar(200)");

            modelBuilder.Entity<Domain.Entities.ProductEntity>()
                .Property(x => x.Price).HasColumnType("decimal(10, 2)");
        }
    }
}

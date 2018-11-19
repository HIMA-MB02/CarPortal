using VahanBlog.Entities;
using System.Data.Entity;

namespace VahanBlog.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<MakeFilters> MakeFilters { get; set; }
        public DbSet<Images> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlogPost>();
            modelBuilder.Entity<Car>();
            modelBuilder.Entity<MakeFilters>();
        }
    }
}
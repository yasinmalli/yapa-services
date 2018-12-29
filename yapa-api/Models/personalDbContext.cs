using Microsoft.EntityFrameworkCore;

namespace yapa_api.Models
{
    public partial class personalDbContext : DbContext
    {
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }

        public personalDbContext(DbContextOptions<personalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseType>(entity =>
            {
                entity.ToTable("ExpenseTypes");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.TypeId).HasColumnName("TypeId");
                entity.Property(e => e.Type).HasColumnName("Type");
                entity.Property(e => e.Description).HasColumnName("Description");
            });
            

        }
    }
}

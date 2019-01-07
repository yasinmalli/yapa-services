using Microsoft.EntityFrameworkCore;
using System;

namespace yapa_api.Models
{
    public partial class personalDbContext : DbContext
    {
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<MainCategory> MainCategory { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }

        public personalDbContext(DbContextOptions<personalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainCategory>(entity =>
            {
                entity.ToTable("expense_main_category");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id").IsRequired();
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(400).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(4000).HasColumnName("description");

                entity.HasMany(e => e.SubCategories).WithOne(e => e.MainCategory);
                entity.HasMany(e => e.Expenses).WithOne(e => e.MainCategory);
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable("expense_sub_category");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");                
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.MainCategoryId).HasColumnName("maincategoryid");

                entity.Ignore(e => e.MainCategoryName);
                entity.HasOne(e => e.MainCategory)
                      .WithMany(d => d.SubCategories)
                      .HasForeignKey(k => k.MainCategoryId)
                      .HasConstraintName("FK_sub_category_main_category_id");
                entity.HasMany(e => e.Expenses).WithOne(e => e.SubCategory);
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.ToTable("expenses");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.ExpenseId).HasColumnName("expenseid");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.Time).HasColumnName("time");
                entity.Property(e => e.CreatedOn).HasColumnName("createdon");
                entity.Property(e => e.SpentAt).HasColumnName("spentat");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.MainCategoryId).HasColumnName("maincategoryid");
                entity.Property(e => e.SubCategoryId).HasColumnName("subcategoryid");
                entity.Property(e => e.ExpenseType).HasColumnName("expensetype")
                      .HasConversion(t => t.ToString(), t => (ExpenseType)Enum.Parse(typeof(ExpenseType), t));

                entity.Ignore(e => e.MainCategoryName).Ignore(e => e.SubCategoryName);
                entity.HasOne(e => e.MainCategory)
                      .WithMany(d => d.Expenses)
                      .HasForeignKey(k => k.MainCategoryId)
                      .HasConstraintName("FK_expenses_main_category_id");
                entity.HasOne(e => e.SubCategory)
                      .WithMany(d => d.Expenses)
                      .HasForeignKey(k => k.SubCategoryId)
                      .HasConstraintName("FK_expenses_sub_category_id");
            });            
        }
    }
}

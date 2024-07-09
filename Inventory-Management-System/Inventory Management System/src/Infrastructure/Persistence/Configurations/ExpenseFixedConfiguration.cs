using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ExpenseFixedConfiguration : IEntityTypeConfiguration<ExpenseFixed>
    {
        public void Configure(EntityTypeBuilder<ExpenseFixed> builder)
        {
            // Table name
            builder.ToTable("ExpenseFixed");

            // Primary key
            builder.HasKey(e => e.Id);

            // Property configurations
            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Amount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(e => e.IntervalDays)
                   .IsRequired();

            builder.Property(e => e.CostPerDay)
                   .HasColumnType("decimal(18,2)");

            builder.Property(e => e.InsertDate)
                   .IsRequired()
                   .HasColumnType("datetime");

            // Seed data
            builder.HasData(
                new ExpenseFixed { Id = 1, Name = "Rent", Amount = 1200.00m, IntervalDays = 30, CostPerDay = 40.00m, InsertDate = DateTime.Now },
                new ExpenseFixed { Id = 2, Name = "Internet", Amount = 50.00m, IntervalDays = 30, CostPerDay = 1.67m, InsertDate = DateTime.Now },
                new ExpenseFixed { Id = 3, Name = "Electricity", Amount = 100.00m, IntervalDays = 30, CostPerDay = 3.33m, InsertDate = DateTime.Now },
                new ExpenseFixed { Id = 4, Name = "Insurance", Amount = 300.00m, IntervalDays = 365, CostPerDay = 0.82m, InsertDate = DateTime.Now },
                new ExpenseFixed { Id = 5, Name = "Maintenance", Amount = 150.00m, IntervalDays = 90, CostPerDay = 1.67m, InsertDate = DateTime.Now }
            );
        }
    }
}

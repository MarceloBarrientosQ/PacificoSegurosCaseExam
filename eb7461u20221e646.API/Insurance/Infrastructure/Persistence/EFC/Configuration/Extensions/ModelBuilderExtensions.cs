using Microsoft.EntityFrameworkCore;

namespace eb7461u20221e646.API.Insurance.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyInsuranceConfigurations(this ModelBuilder builder)
    {
        // Insurance Bounded Context
        builder.Entity<Domain.Model.Aggregate.Insurance>(insurance =>
        {
            insurance.HasKey(i => i.InsuranceId);

            insurance.Property(i => i.InsuranceId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            insurance.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            insurance.Property(i => i.CreatedAt)
                .IsRequired();

            insurance.Property(i => i.UpdatedAt)
                .IsRequired();
            
            insurance.Property(i => i.RegisteredDate)
                .IsRequired();

            // Category Value Object
            insurance.OwnsOne(i => i.Category, category =>
            {
                category.Property(c => c.Value)
                    .HasColumnName("Category")
                    .IsRequired()
                    .HasMaxLength(50);
            });

            // SubCategory Value Object
            insurance.OwnsOne(i => i.Subcategory, subcategory =>
            {
                subcategory.Property(s => s.Value)
                    .HasColumnName("Subcategory")
                    .IsRequired()
                    .HasMaxLength(80);
            });
        });
    }
}
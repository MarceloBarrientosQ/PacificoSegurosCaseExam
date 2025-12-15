using eb7461u20221e646.API.Sinister.Domain.Model.Entities;
using eb7461u20221e646.API.Sinister.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace eb7461u20221e646.API.Sinister.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtension
{
    public static void ApplySinisterConfigurations(this ModelBuilder builder)
    {
        // Sinister Bounded Context
        builder.Entity<Domain.Model.Aggregate.Sinister>(sinister =>
        {
            sinister.HasKey(e => e.SinisterId);

            sinister.Property(e => e.SinisterId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            // CustomerId como Owned Type
            sinister.OwnsOne(s => s.CustomerId, customerId =>
            {
                customerId.Property(c => c.Id)
                    .HasColumnName("CustomerId")
                    .IsRequired();
            });

            // InsuranceId como Owned Type
            sinister.OwnsOne(s => s.InsuranceId, insuranceId =>
            {
                insuranceId.Property(i => i.Id)
                    .HasColumnName("InsuranceId")
                    .IsRequired();
            });

            sinister.Property(s => s.SinisterType)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            sinister.Property(s => s.DateAt)
                .IsRequired();

            sinister.Property(s => s.CreatedAt)
                .IsRequired();

            sinister.Property(s => s.UpdatedAt)
                .IsRequired();
        });

        // Customer Entity
        builder.Entity<Customer>(customer =>
        {
            customer.ToTable("Customers");

            customer.HasKey(c => c.Id);

            // Conversor explícito para CustomerId
            customer.Property(c => c.Id)
                .HasColumnName("customerId")
                .IsRequired()
                .HasConversion<int>(
                    v => v.Id,               // CustomerId -> int
                    v => new CustomerId(v)   // int -> CustomerId
                );

            customer.Property(c => c.FirstName)
                .HasColumnName("firstName")
                .IsRequired()
                .HasMaxLength(50);

            customer.Property(c => c.LastName)
                .HasColumnName("lastName")
                .IsRequired()
                .HasMaxLength(50);

            customer.Property(c => c.Sex)
                .HasColumnName("sex")
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(1);

            customer.Property(c => c.BirthDate)
                .HasColumnName("birthDate")
                .IsRequired();

            customer.Property(c => c.Sinisters)
                .HasColumnName("sinisters")
                .IsRequired();

            // Seed data: usar CustomerId value objects para coincidir con el tipo CLR
            customer.HasData(
                new
                {
                    Id = new CustomerId(1),
                    FirstName = "Willie",
                    LastName = "Colon",
                    Sex = ESex.M,
                    BirthDate = new DateTime(1980, 1, 1),
                    Sinisters = 0
                },
                new
                {
                    Id = new CustomerId(2),
                    FirstName = "Celia",
                    LastName = "Cruz",
                    Sex = ESex.F,
                    BirthDate = new DateTime(1990, 10, 10),
                    Sinisters = 0
                },
                new
                {
                    Id = new CustomerId(3),
                    FirstName = "Ismael",
                    LastName = "Rivera",
                    Sex = ESex.M,
                    BirthDate = new DateTime(1985, 8, 8),
                    Sinisters = 0
                },
                new
                {
                    Id = new CustomerId(4),
                    FirstName = "Yolanda",
                    LastName = "Rivera",
                    Sex = ESex.F,
                    BirthDate = new DateTime(1995, 9, 4),
                    Sinisters = 0
                },
                new
                {
                    Id = new CustomerId(5),
                    FirstName = "Oscar",
                    LastName = "De Leon",
                    Sex = ESex.M,
                    BirthDate = new DateTime(1975, 12, 25),
                    Sinisters = 0
                },
                new
                {
                    Id = new CustomerId(6),
                    FirstName = "India",
                    LastName = "Caballero",
                    Sex = ESex.F,
                    BirthDate = new DateTime(1970, 7, 6),
                    Sinisters = 0
                }
            );

        });
    }
}

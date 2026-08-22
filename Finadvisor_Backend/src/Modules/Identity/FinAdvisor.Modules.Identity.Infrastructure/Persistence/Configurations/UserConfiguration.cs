using FinAdvisor.Modules.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinAdvisor.Modules.Identity.Infrastructure.Persistence.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
                .ValueGeneratedNever();

            builder.Property(user => user.Email)
                .HasMaxLength(320)
                .IsRequired();

            builder.HasIndex(user => user.Email)
                .IsUnique();

            builder.Property(user => user.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(user => user.FamilyName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(user => user.PasswordHash)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(user => user.Role)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(user => user.Status)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(user => user.CreatedAtUtc)
                .IsRequired();

            builder.Property(user => user.UpdatedAtUtc);
            builder.Ignore(user => user.DomainEvents);
        }
    }
}

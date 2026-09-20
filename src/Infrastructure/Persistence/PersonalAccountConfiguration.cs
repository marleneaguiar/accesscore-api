using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class PersonalAccountConfiguration
       : IEntityTypeConfiguration<PersonalAccount>
    {
        public void Configure(EntityTypeBuilder<PersonalAccount> builder)
        {
            builder.ToTable("personal_accounts");
            builder.HasKey(account => account.Id);
            builder.Property(account => account.Name)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(account => account.Email)
                   .IsRequired()
                   .HasMaxLength(255);
            builder.HasIndex(account => account.Email)
                   .IsUnique();
            builder.Property(account => account.PasswordHash)
                   .IsRequired();
            builder.Property(account => account.CreatedAt)
                   .IsRequired();
        }

    }
}
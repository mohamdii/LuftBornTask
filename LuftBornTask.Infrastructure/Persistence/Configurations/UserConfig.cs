using LuftBornTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Infrastructure.Persistence.Configurations
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.EntraObjectId)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(u => u.EntraObjectId).IsUnique();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}

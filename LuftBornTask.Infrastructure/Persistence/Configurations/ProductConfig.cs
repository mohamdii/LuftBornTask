using LuftBornTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Infrastructure.Persistence.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(Product));

            builder.Property(p => p.Name)
         .IsRequired()
         .HasMaxLength(200);

            builder.Property(p => p.Description)
                .HasMaxLength(1000);
        }
    }
}

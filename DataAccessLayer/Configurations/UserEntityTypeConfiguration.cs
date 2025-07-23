using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.Username).HasColumnType("nvarchar").HasMaxLength(64).IsRequired();
            builder.Property(m => m.Email).HasColumnType("nvarchar").HasMaxLength(255).IsRequired();
            builder.Property(m => m.EmailConfirmed).HasColumnType("bit").IsRequired(false);
            builder.Property(m => m.Password).HasColumnType("nvarchar").HasMaxLength(128).IsRequired();

            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("Users");
        }
    }
}

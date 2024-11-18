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
    class CreatorEntityTypeConfiguration : IEntityTypeConfiguration<Creator>
    {
        public void Configure(EntityTypeBuilder<Creator> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.NickName).HasColumnType("nvarchar").HasMaxLength(400).IsRequired();
            builder.Property(m => m.ChainId).HasColumnType("nvarchar").HasMaxLength(400).IsRequired();
            builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Bio).HasColumnType("nvarchar").HasMaxLength(400).IsRequired();
            builder.Property(m => m.Followers).HasColumnType("int").IsRequired();
            builder.Property(m => m.Volume).HasColumnType("int").IsRequired();
            builder.Property(m => m.SoldNFts).HasColumnType("int").IsRequired();
            builder.Property(m => m.ImagePath).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("Creators");
        }
    }
}

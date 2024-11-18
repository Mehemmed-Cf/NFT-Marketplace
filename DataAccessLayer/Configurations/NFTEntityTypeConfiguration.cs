using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    class NFTEntityTypeConfiguration : IEntityTypeConfiguration<NFT>
    {
        public void Configure(EntityTypeBuilder<NFT> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.CreatorId).HasColumnType("int");
            builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(400).IsRequired();
            builder.Property(m => m.Description).HasColumnType("nvarchar").HasMaxLength(400).IsRequired();
            builder.Property(m => m.Price).HasColumnType("smallint").IsRequired();
            builder.Property(m => m.HighestBid).HasColumnType("smallint").IsRequired();
            builder.Property(m => m.ImagePath).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("NFTs");
        }
    }
}

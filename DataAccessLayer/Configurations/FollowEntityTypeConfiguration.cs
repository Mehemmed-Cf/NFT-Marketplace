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
    class FollowEntityTypeConfiguration : IEntityTypeConfiguration<Follow>
    {
        public DateTime FollowedAt { get; set; } = DateTime.UtcNow;
        public User User { get; set; }
        public Creator Creator { get; set; }

        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            //builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            //builder.Property(m => m.UserId).HasColumnType("int").IsRequired();
            //builder.Property(m => m.CreatorId).HasColumnType("int").IsRequired();
            //builder.HasOne(m => m.User).WithMany(u => u.Follows).HasForeignKey(m => m.UserId).OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(m => m.Creator).WithMany(u => u.Follows).HasForeignKey(m => m.CreatorId).OnDelete(DeleteBehavior.Cascade);

            //builder.ConfigureAuditable();
            //builder.HasKey(m => m.Id);
            //builder.ToTable("Follows");
        }
    }
}

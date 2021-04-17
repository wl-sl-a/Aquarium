using Aquarium.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquarium.DAL.Configurations
{
    public class FishConfiguration : IEntityTypeConfiguration<Fish>
    {
        public void Configure(EntityTypeBuilder<Fish> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Kind)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Count)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.NameCompany)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(m => m.Aquarium)
                .WithMany(a => a.Fishes)
                .HasForeignKey(m => m.AquariumId);

            builder
                .ToTable("Fishes");
        }
    }
}

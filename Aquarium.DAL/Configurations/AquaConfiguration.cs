using Aquarium.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquarium.DAL.Configurations
{
    public class AquaConfiguration : IEntityTypeConfiguration<AquariumM>
    {
        public void Configure(EntityTypeBuilder<AquariumM> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Manufacturer)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Volume)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Length)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Width)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Height)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.NameCompany)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Aquariums");
        }
    }
}

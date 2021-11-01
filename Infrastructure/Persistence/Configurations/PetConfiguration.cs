using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static PetClinic.Domain.Models.ModelConstants.Common;

namespace Infrastructure.Persistence.Configurations
{
    internal class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(p => p.Age)
                .IsRequired();

            builder
                .Property(p => p.PicutreUrl)
                .HasMaxLength(MaxUrlLength);
        }
    }
}

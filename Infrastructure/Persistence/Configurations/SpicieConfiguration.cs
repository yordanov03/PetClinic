using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    internal class SpicieConfiguration : IEntityTypeConfiguration<Spicie>
    {
        public void Configure(EntityTypeBuilder<Spicie> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Name)
                .IsRequired();
        }
    }
}

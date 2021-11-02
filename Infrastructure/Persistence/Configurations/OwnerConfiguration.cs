using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static PetClinic.Domain.Models.ModelConstants.PhoneNumber;

namespace Infrastructure.Persistence.Configurations
{
    internal class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .HasMany(o => o.Pets)
                .WithOne()
                .HasForeignKey(p => p.Id);

            builder
                .Property(o => o.PhoneNumber)
                .HasMaxLength(MaxPhoneNumberLength);
        }
    }
}

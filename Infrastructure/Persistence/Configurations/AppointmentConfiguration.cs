using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static PetClinic.Domain.Models.ModelConstants.Common;

namespace Infrastructure.Persistence.Configurations
{
    internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Diagnose)
                .HasMaxLength(MaxDiagnoseLength)
                .ValueGeneratedOnUpdate();

            builder
                .Property(a => a.AppointmentTime)
                .IsRequired();

            builder
                .HasOne(a => a.Pet)
                .WithMany()
                .HasForeignKey("PetId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

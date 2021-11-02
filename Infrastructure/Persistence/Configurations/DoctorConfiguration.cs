using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static PetClinic.Domain.Models.ModelConstants.Common;

namespace Infrastructure.Persistence.Configurations
{
    internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .HasMany(d => d.Appointments)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("appointments");


            builder
                .HasMany(d => d.Patients)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("patients");
            ;
        }
    }
}

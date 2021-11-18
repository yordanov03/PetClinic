using Application.Mapping;
using AutoMapper;
using Domain.Models;
using System;

namespace Application.Features.Appointments
{
    public class AppointmentOutputModel : IMapFrom<Appointment>
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = default!;
        public string Diagnose { get; set; } = default!;
        public DateTime AppointmentTime { get; private set; } = default!;
        public string PetName { get; set; } = default!;
        public string DoctorName { get; private set; } = default!;
        public string OwnerName { get; private set; } = default!;
        public string OwnerPhoneNumber { get; private set; } = default!;

        public void Mapping(Profile mapper) =>
            mapper.CreateMap<Appointment, AppointmentOutputModel>()
            .ForMember(a => a.PetName, cfg => cfg.MapFrom(a => a.Pet.Name))
            .ForMember(a => a.OwnerName, cfg => cfg.MapFrom(a => a.Pet.Owner.Name))
            .ForMember(a => a.OwnerPhoneNumber, cfg => cfg.MapFrom(a => a.Pet.Owner.PhoneNumber));
    }
}

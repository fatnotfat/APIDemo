using AutoMapper;
using BusinessObjects;
using Health360Scheduler.DataTransferObjects;

namespace Health360Scheduler.Mappers
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<DoctorDTO, Doctor>()
            .ForMember(
                dest => dest.DoctorID,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName)
            )
            .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName)
            )
            .ForMember(
                dest => dest.PhoneNumber,
                opt => opt.MapFrom(src => src.PhoneNumber)
            )
            .ForMember(
                dest => dest.Specialty,
                opt => opt.MapFrom(src => src.Specialty)
            )
            .ForMember(
                dest => dest.AccountId,
                opt => opt.MapFrom(src => src.AccountId)
            );
            CreateMap<Doctor, DoctorDTO>();
        }
    }
}

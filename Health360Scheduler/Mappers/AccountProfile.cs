using AutoMapper;
using Health360Scheduler.DataTransferObjects;
using BusinessObjects;

namespace Health360Scheduler.Mappers
{
    public class AccountFrofile : Profile
    {
        public AccountFrofile()
        {
            CreateMap<AccountDTO, Account>()
            .ForMember(
                dest => dest.AccountId,
                opt => opt.MapFrom(src => Guid.NewGuid())
            )
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email)
            )
            .ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => src.Password)
            )
            .ForMember(
                dest => dest.Role,
                opt => opt.MapFrom(src => src.Role)
            )
            .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => src.Role)
            );
            CreateMap<Account, AccountDTO>();
        }
    }
}

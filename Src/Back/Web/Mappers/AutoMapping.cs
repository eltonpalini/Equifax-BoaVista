using AutoMapper;
using Web.Requests;
namespace Web.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<UserRequest, Domain.User>()
                .ForMember(x => x.Login, opt => opt.MapFrom(z => z.Login))
                .ForMember(x => x.Password, opt => opt.MapFrom(z => z.Password));                
        }
    }
}

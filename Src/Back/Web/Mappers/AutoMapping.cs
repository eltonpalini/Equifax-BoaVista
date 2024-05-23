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

            CreateMap<CourseRequest, Domain.Course>()
                .ForMember(x => x.Name, opt => opt.MapFrom(z => z.Name))
                .ForMember(x => x.Price, opt => opt.MapFrom(z => z.Price))
                .ForMember(x => x.BillingType, opt => opt.MapFrom(z => z.BillingType));

            CreateMap<StudentRequest, Domain.Student>()
                .ForMember(x => x.Name, opt => opt.MapFrom(z => z.Name))
                .ForPath(x => x.User.Login, opt => opt.MapFrom(z => z.Login))
                .ForPath(x => x.User.Password, opt => opt.MapFrom(z => z.Password));

            CreateMap<BillingRequest, Domain.Billing>()
                .ForMember(x => x.CourseId, opt => opt.MapFrom(z => z.CourseId))
                .ForMember(x => x.StudentId, opt => opt.MapFrom(z => z.StudentId))
                .ForMember(x => x.Amount, opt => opt.MapFrom(z => z.Amount));
        }
    }
}

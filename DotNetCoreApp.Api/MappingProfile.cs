using AutoMapper;
using DataAccess.Entities;
using Model.Dtos;

namespace DotNetCoreApp.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.ClassName))
                .ReverseMap();

            CreateMap<Class, ClassDto>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();
        }
    }
}
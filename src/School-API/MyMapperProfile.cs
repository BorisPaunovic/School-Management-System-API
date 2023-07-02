using AutoMapper;
using School.BusinessModels.Responce.Students;
using School.DataModels.Responce.Students;

namespace School_API
{
    public class MyMapperProfile:Profile
    {
        public MyMapperProfile() 
        {
            CreateMap<Student, GetStudentResponce>().ForMember(dest => dest.Id, o => o.MapFrom(src => src.StudentId)).ReverseMap();
        }
    }
}

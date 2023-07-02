using AutoMapper;
using School.BusinessModels.Responce.Students;
using School.DataModels.Models;
using School.DataModels.Responce.Students;
using System.Collections;
using System.Collections.Generic;

namespace School.Mapper
{
    public class DataToBusinessMapper : Profile
    {
        public DataToBusinessMapper()
        {
            this.CreateMap<Student, GetStudentResponce>().ForMember(s => s.Id, b => b.MapFrom(c => c.StudentId)).ReverseMap();


            this.CreateMap<Countries, CountriesBL<Countries>>().ForPath(countries => countries.Data.CountriesID, element => element.MapFrom(countriesBL => countriesBL.CountriesID))
                .ForPath(countries => countries.Data.ISO, element => element.MapFrom(countriesBL => countriesBL.ISO))
                .ForPath(countries => countries.Data.CountryName, element => element.MapFrom(countriesBL => countriesBL.CountryName))
                .ForPath(countries => countries.Data.Deleted, element => element.MapFrom(countriesBL => countriesBL.Deleted))
                .ForPath(countries => countries.Data.PhoneCode, element => element.MapFrom(countriesBL => countriesBL.PhoneCode))
                .ForPath(countries => countries.Data.ISO3, element => element.MapFrom(countriesBL => countriesBL.ISO3)).ReverseMap();


            this.CreateMap<Courses, CoursesBL<Courses>>().ForPath(courses => courses.Data.CoursesID, element => element.MapFrom(coursesBL => coursesBL.CoursesID))
             .ForPath(courses => courses.Data.CoursesDescription, element => element.MapFrom(countriesBL => countriesBL.CoursesDescription))
             .ForPath(courses => courses.Data.CoursesName, element => element.MapFrom(countriesBL => countriesBL.CoursesName))
             .ForPath(courses => courses.Data.Deleted, element => element.MapFrom(countriesBL => countriesBL.Deleted))
             .ReverseMap();

            this.CreateMap<StudentsResault, StudentsResaultBL<StudentsResault>>().ForPath(countries => countries.Data.StudentsID, element => element.MapFrom(countriesBL => countriesBL.StudentsID))
                .ForPath(countries => countries.Data.FirstName, element => element.MapFrom(countriesBL => countriesBL.FirstName))
                .ForPath(countries => countries.Data.Email, element => element.MapFrom(countriesBL => countriesBL.Email))
                .ForPath(countries => countries.Data.LastName, element => element.MapFrom(countriesBL => countriesBL.LastName))
                .ForPath(countries => countries.Data.Gender, element => element.MapFrom(countriesBL => countriesBL.Gender))
                .ForPath(countries => countries.Data.DateOfBirth, element => element.MapFrom(countriesBL => countriesBL.DateOfBirth))
                .ForPath(countries => countries.Data.Adress, element => element.MapFrom(countriesBL => countriesBL.Adress))
                .ForPath(countries => countries.Data.CoursesName, element => element.MapFrom(countriesBL => countriesBL.CoursesName))
                .ForPath(countries => countries.Data.CountryName, element => element.MapFrom(countriesBL => countriesBL.CountryName))
                .ForPath(countries => countries.Data.Passed, element => element.MapFrom(countriesBL => countriesBL.Passed))
                .ForPath(countries => countries.Data.StartDate, element => element.MapFrom(countriesBL => countriesBL.StartDate))
                .ForPath(countries => countries.Data.CoursesDescription, element => element.MapFrom(countriesBL => countriesBL.CoursesDescription)).ReverseMap();


            this.CreateMap<Students, StudentsBL<Students>>().ForPath(countries => countries.Data.StudentsID, element => element.MapFrom(countriesBL => countriesBL.StudentsID))
                .ForPath(countries => countries.Data.FirstName, element => element.MapFrom(countriesBL => countriesBL.FirstName))
                .ForPath(countries => countries.Data.Email, element => element.MapFrom(countriesBL => countriesBL.Email))
                .ForPath(countries => countries.Data.LastName, element => element.MapFrom(countriesBL => countriesBL.LastName))
                .ForPath(countries => countries.Data.Gender, element => element.MapFrom(countriesBL => countriesBL.Gender))
                .ForPath(countries => countries.Data.DateOfBirth, element => element.MapFrom(countriesBL => countriesBL.DateOfBirth))
                .ForPath(countries => countries.Data.Adress, element => element.MapFrom(countriesBL => countriesBL.Adress))
                .ForPath(countries => countries.Data.CountriesID, element => element.MapFrom(countriesBL => countriesBL.CountriesID))
                .ForPath(countries => countries.Data.Deleted, element => element.MapFrom(countriesBL => countriesBL.Deleted))
               .ReverseMap();



            this.CreateMap<Subjects, SubjectsBL<Subjects>>().ForPath(courses => courses.Data.SubjectId, element => element.MapFrom(coursesBL => coursesBL.SubjectId))
             .ForPath(courses => courses.Data.SubjectDescription, element => element.MapFrom(countriesBL => countriesBL.SubjectDescription))
             .ForPath(courses => courses.Data.SubjectName, element => element.MapFrom(countriesBL => countriesBL.SubjectName))
             .ForPath(courses => courses.Data.Deleted, element => element.MapFrom(countriesBL => countriesBL.Deleted))
             .ReverseMap();


            this.CreateMap<TeachersJoinCoursesResault, TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>>().ForPath(countries => countries.Data.TeachersId, element => element.MapFrom(countriesBL => countriesBL.TeachersId))
                .ForPath(countries => countries.Data.FirstName, element => element.MapFrom(countriesBL => countriesBL.FirstName))
                .ForPath(countries => countries.Data.Email, element => element.MapFrom(countriesBL => countriesBL.Email))
                .ForPath(countries => countries.Data.LastName, element => element.MapFrom(countriesBL => countriesBL.LastName))
                .ForPath(countries => countries.Data.Gender, element => element.MapFrom(countriesBL => countriesBL.Gender))
                .ForPath(countries => countries.Data.DateOfBirth, element => element.MapFrom(countriesBL => countriesBL.DateOfBirth))
                .ForPath(countries => countries.Data.Adress, element => element.MapFrom(countriesBL => countriesBL.Adress))
                .ForPath(countries => countries.Data.CoursesName, element => element.MapFrom(countriesBL => countriesBL.CoursesName))
                .ForPath(countries => countries.Data.TeachersCoursesId, element => element.MapFrom(countriesBL => countriesBL.TeachersCoursesId))
                .ForPath(countries => countries.Data.CoursesId, element => element.MapFrom(countriesBL => countriesBL.CoursesId))
                .ForPath(countries => countries.Data.CoursesDescription, element => element.MapFrom(countriesBL => countriesBL.CoursesDescription)).ReverseMap();



            this.CreateMap<TeachersCourses, TeachersCoursesBL<TeachersCourses>>().ForPath(courses => courses.Data.TeachersCoursesId, element => element.MapFrom(coursesBL => coursesBL.TeachersCoursesId))
          .ForPath(courses => courses.Data.TeachersId, element => element.MapFrom(countriesBL => countriesBL.TeachersId))
          .ForPath(courses => courses.Data.CoursesId, element => element.MapFrom(countriesBL => countriesBL.CoursesId))
          .ReverseMap();



            this.CreateMap<Teachers, TeachersBL<Teachers>>().ForPath(courses => courses.Data.TeachersId, element => element.MapFrom(coursesBL => coursesBL.TeachersId))
             .ForPath(courses => courses.Data.FirstName, element => element.MapFrom(countriesBL => countriesBL.FirstName))
             .ForPath(courses => courses.Data.LastName, element => element.MapFrom(countriesBL => countriesBL.LastName))
             .ForPath(courses => courses.Data.Deleted, element => element.MapFrom(countriesBL => countriesBL.Deleted))
             .ForPath(courses => courses.Data.Email, element => element.MapFrom(countriesBL => countriesBL.Email))
             .ForPath(courses => courses.Data.Gender, element => element.MapFrom(countriesBL => countriesBL.Gender))
             .ForPath(courses => courses.Data.DateOfBirth, element => element.MapFrom(countriesBL => countriesBL.DateOfBirth))
              .ForPath(courses => courses.Data.Adress, element => element.MapFrom(countriesBL => countriesBL.Adress))
             .ReverseMap();


            this.CreateMap<CoursesSubjects,CoursesSubjectsBL<CoursesSubjects>>().ForPath(courses => courses.Data.CoursesSubjectsId, element => element.MapFrom(coursesBL => coursesBL.CoursesSubjectsId))
         .ForPath(courses => courses.Data.CoursesId, element => element.MapFrom(countriesBL => countriesBL.CoursesId))
         .ForPath(courses => courses.Data.SubjectsId, element => element.MapFrom(countriesBL => countriesBL.SubjectsId))
         .ReverseMap();


            this.CreateMap<StudentCourses, StudentCoursesBL<StudentCourses>>().ForPath(courses => courses.Data.StudentsCoursesID, element => element.MapFrom(coursesBL => coursesBL.StudentsCoursesID))
            .ForPath(courses => courses.Data.StudentsID, element => element.MapFrom(countriesBL => countriesBL.StudentsID))
            .ForPath(courses => courses.Data.CoursesID, element => element.MapFrom(countriesBL => countriesBL.CoursesID))
            .ForPath(courses => courses.Data.Passed, element => element.MapFrom(countriesBL => countriesBL.Passed))
            .ForPath(courses => courses.Data.StartDate, element => element.MapFrom(countriesBL => countriesBL.StartDate))
            .ReverseMap();




            this.CreateMap<Users, UsersBL<Users>>().ForPath(countries => countries.Data.UsersID, element => element.MapFrom(countriesBL => countriesBL.UsersID))
                .ForPath(countries => countries.Data.UserName, element => element.MapFrom(countriesBL => countriesBL.UserName))
                .ForPath(countries => countries.Data.UserPassword, element => element.MapFrom(countriesBL => countriesBL.UserPassword))
                .ForPath(countries => countries.Data.Deleted, element => element.MapFrom(countriesBL => countriesBL.Deleted))
                .ForPath(countries => countries.Data.UserEmail, element => element.MapFrom(countriesBL => countriesBL.UserEmail))
                .ForPath(countries => countries.Data.Administrator, element => element.MapFrom(countriesBL => countriesBL.Administrator)).ReverseMap();

          






        }

    }
}

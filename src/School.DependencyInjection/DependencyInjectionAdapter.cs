
using Microsoft.Extensions.DependencyInjection;
using School.BusinessLogic;
using School.BusinessLogic.Interfaces;
using School.BusinessLogic.Interfaces.IJointClassesBusinessLogic;
using School.BusinessLogic.JointClassesBusinessLogic;
using School.Services;
using School.Services.Interfaces;
using School.Services.Interfaces.IJointClassesBusinessLogic;
using School.Services.JointClassesBusinessLogic;

namespace School.DependencyInjection
{
    public static class DependencyInjectionAdapter
    {

        public static void AddMyServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentBusinessLogic, StudentBusinessLogic>();
            services.AddScoped<IStudentService, StudentService>();



            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped<ICountriesBusinessLogic, CountriesBusinessLogic>();

            services.AddScoped<ICourseBusinessLogic, CoursesBusinessLogic>();
            services.AddScoped<ICourseService, CoursesService>();

            services.AddScoped<IStudentsBusinessLogic, StudentsBusinessLogic>();
            services.AddScoped<IStudentsService, StudentsService>();

            services.AddScoped<ISubjectsBusinessLogic, SubjectsBusinessLogic>();
            services.AddScoped<ISubjectsServices, SubjectsServices>();

          services.AddScoped<ITeachersBusinessLogic, TeachersBusinessLogic>();
            services.AddScoped<ITeacherServices, TeachersServices>();

            services.AddScoped<IUsersBusinessLogic,UsersBusinessLogic>();
            services.AddScoped<IUsersServices, UsersServices>();

            services.AddScoped<ITeacherCoursesBusinessLogic, TeacherCoursesBusinessLogic>();
            services.AddScoped<ITeacherCoursesServices, TeacherCoursesServices>();

            services.AddScoped<ICoursesSubjectsBusinessLogic, CoursesSubjectsBusinessLogic>();
            services.AddScoped<ICoursesSubjectsServices, CoursesSubjectsServices>();

            services.AddScoped<IStudentCoursesBusinessLogic, StudentCoursesBusinessLogic>();
            services.AddScoped<IStudentCoursesServices, StudentCoursesServices>();
        }
    }
}

using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Interfaces.IJointClassesBusinessLogic
{
    public interface IStudentCoursesServices
    {

        public bool AddStudentCourse(StudentCourses studentCourses);

        public bool UpdateStudentCourse(StudentCourses studentCourses);
        
    }
}

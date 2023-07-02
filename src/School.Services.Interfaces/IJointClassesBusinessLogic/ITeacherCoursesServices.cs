using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Interfaces.IJointClassesBusinessLogic
{
    public interface ITeacherCoursesServices
    {

        public bool AddTeacherCourses(TeachersCourses teachersCourses);

        public bool UpdateTeachersCourses(TeachersCourses teachersCourses);
       
    }
}

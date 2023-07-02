using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic.Interfaces.IJointClassesBusinessLogic
{
    public interface IStudentCoursesBusinessLogic
    {
        #region StudentCourses Functions
        public bool AddStudentCourse(StudentCourses studentCourses);

        public  bool UpdateStudentCourse(StudentCourses studentCourses);

        #endregion

        #region StdentCoursesBL Functions

        public bool AddStudentCourseBL(StudentCoursesBL<StudentCourses> studentCoursesBL);

        public bool UpdateStudentCourseBL(StudentCoursesBL<StudentCourses> studentCoursesBL);
        
        #endregion
    }
}

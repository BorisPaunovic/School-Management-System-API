using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic.Interfaces.IJointClassesBusinessLogic
{
    public interface ITeacherCoursesBusinessLogic
    {

        #region TC Functions
        public bool AddTeacherCourses(TeachersCourses teachersCourses);


        public bool UpdateTeachersCourses(TeachersCourses teachersCourses);

        #endregion


        #region TCBL Functions
        public bool AddTeacherCoursesBL(TeachersCoursesBL<TeachersCourses> teachersCoursesBL);


        public bool UpdateTeachersCoursesBL(TeachersCoursesBL<TeachersCourses> teachersCoursesBL);

        #endregion

    }
}

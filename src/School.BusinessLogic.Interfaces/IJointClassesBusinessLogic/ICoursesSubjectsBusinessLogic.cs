using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic.Interfaces.IJointClassesBusinessLogic
{
    public  interface ICoursesSubjectsBusinessLogic
    {
        #region CourseSubject Functions
        public bool AddCourseSubject(CoursesSubjects coursesSubjects);

        public List<CoursesSubjects> SelectAllCourses();

        public List<CoursesSubjects> SelectCoursesSubjectsById(int CoursesId);

        public bool UpdateCoursesSubjects(CoursesSubjects coursesSubject);


        #endregion

        #region CourseSubjectBL Function
        public bool AddCourseSubjectBL(CoursesSubjectsBL<CoursesSubjects> coursesSubjects);

        public List<CoursesSubjectsBL<CoursesSubjects>> SelectAllCoursesBL();

        public List<CoursesSubjectsBL<CoursesSubjects>> SelectCoursesSubjectsByIdBL(int CoursesId);

        public bool UpdateCoursesSubjectsBL(CoursesSubjectsBL<CoursesSubjects> coursesSubject);
        #endregion
    }
}

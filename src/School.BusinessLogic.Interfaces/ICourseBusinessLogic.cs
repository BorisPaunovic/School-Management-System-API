using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic.Interfaces
{
    public interface ICourseBusinessLogic
    {

        #region Course Functions
        public Courses SelectCourseByName(string CoursesName);


        public List<Courses> SelectAllCourses();


        public bool SaveCourse(Courses course);


        public bool ValidateCourse(bool IsNameValid, bool IsDescriptionValid, bool _isClbSubjectsValid);

        public CoursesBL<Courses> SelectCourseBLByID(int CourseId);

        public bool ValidateCoursename(string CourseName);


        public bool ValidateCourseDescription(string CourseDescription);


        public bool ValidateClbSubjects( object checkedListBox);


        public bool UpdateCourse(Courses course);


        public bool DeleteCourse(int CourseId);




       

        #endregion








        #region CourseBL Functions

        public CoursesBL<Courses> SelectCourseByNameBL(string CoursesName);


        public List<CoursesBL<Courses>> SelectAllCoursesBL();


        public bool SaveCourseBL(CoursesBL<Courses> course);


     

        public bool UpdateCourseBL(CoursesBL<Courses> course);


        public bool DeleteCourseBL(int CourseId);




        public List<CoursesBL<Courses>> FilterByCourseNameBL(List<CoursesBL<Courses>> courses, string TextBox);

        #endregion


    }
}

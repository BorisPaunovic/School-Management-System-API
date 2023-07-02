using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic.Interfaces
{
    public interface ICourseService
    {

        public bool UpdateCourse(Courses course);


        public bool DeleteCourse(int CourseId);


        public List<Courses> SelectAllCourses();



        public bool SaveCourse(Courses course);
            

        public Courses SelectCourseByName(string CoursesName);
        public Courses SelectCourseByID(int CourseId);


    }
}

using School.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Interfaces.IJointClassesBusinessLogic
{
    public interface ICoursesSubjectsServices
    {
        public List<CoursesSubjects> SelectAllCoursesSubjects();


        public List<CoursesSubjects> SelectCoursesSubjectsById(int CoursesID);


        public bool AddCourseSubject(CoursesSubjects coursesSubjects);


        public bool UpdateCourseSubject(CoursesSubjects coursesSubject);


        public bool UpdateCourseSubject2(CoursesSubjects coursesSubject);
       

    }
}

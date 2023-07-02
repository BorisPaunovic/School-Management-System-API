using AutoMapper;
using Microsoft.AspNetCore.Http;
using School.BusinessLogic.Interfaces.IJointClassesBusinessLogic;
using School.DataModels.Models;
using School.Services.Interfaces.IJointClassesBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic.JointClassesBusinessLogic
{
    public class StudentCoursesBusinessLogic : IStudentCoursesBusinessLogic
    {


        private readonly IStudentCoursesServices _studentCoursesServices;
        private readonly IMapper _mapper;
        public StudentCoursesBusinessLogic(IStudentCoursesServices studentCoursesServices, IMapper mapper)
        {
            this._studentCoursesServices = studentCoursesServices;
            this._mapper = mapper;
        }

        #region StudentCourses Functions

        public bool AddStudentCourse(StudentCourses studentCourses)
        {
            bool IsTeachersCoursesInserted = false;
            IsTeachersCoursesInserted = _studentCoursesServices.AddStudentCourse(studentCourses);
            return IsTeachersCoursesInserted;
        }
        public bool UpdateStudentCourse(StudentCourses studentCourses)
        {
            bool IsCourseSubjectUpdated = false;
            IsCourseSubjectUpdated = _studentCoursesServices.UpdateStudentCourse(studentCourses);
            return IsCourseSubjectUpdated;
        }


        #endregion


        #region StudentCoursesBL Region


        public bool UpdateStudentCourseBL(StudentCoursesBL<StudentCourses> studentCoursesBL)
        {
            StudentCourses studentCourses = new StudentCourses();
          studentCourses = _mapper.Map<StudentCourses>(studentCoursesBL);
            var IsStudentCoursesUpdated =  UpdateStudentCourse(studentCourses);
           return IsStudentCoursesUpdated;
        }
        public bool AddStudentCourseBL(StudentCoursesBL<StudentCourses> studentCoursesBL)
        {
            StudentCourses studentCourses = new StudentCourses();
            studentCourses = _mapper.Map<StudentCourses>(studentCoursesBL);
            var IsStudentCoursesAdded = AddStudentCourse(studentCourses);
            return IsStudentCoursesAdded;
        }
        #endregion



    }
}

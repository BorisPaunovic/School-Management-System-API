using AutoMapper;
using School.BusinessLogic.Interfaces.IJointClassesBusinessLogic;
using School.DataModels.Models;
using School.Services.Interfaces;
using School.Services.Interfaces.IJointClassesBusinessLogic;
using School.Services.JointClassesBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic.JointClassesBusinessLogic
{
    public class TeacherCoursesBusinessLogic: ITeacherCoursesBusinessLogic
    {
        private readonly ITeacherCoursesServices _teacherCoursesServices;
        private readonly IMapper _mapper;
 public TeacherCoursesBusinessLogic(ITeacherCoursesServices teacherCoursesServices, IMapper mapper)
        {
            this._teacherCoursesServices = teacherCoursesServices;
            this._mapper = mapper;
        }

        #region TC Functions
       

        public bool AddTeacherCourses(TeachersCourses teachersCourses)
        {
            bool IsTeachersCoursesInserted = false;
            IsTeachersCoursesInserted = _teacherCoursesServices.AddTeacherCourses(teachersCourses);
            return IsTeachersCoursesInserted;
        }

        public bool UpdateTeachersCourses(TeachersCourses teachersCourses)
        {
            bool IsTeacherCourseUpdated = false;
            IsTeacherCourseUpdated = _teacherCoursesServices.UpdateTeachersCourses (teachersCourses);
            return IsTeacherCourseUpdated;
        }
        #endregion


        #region TCBL Functions
        public bool AddTeacherCoursesBL(TeachersCoursesBL<TeachersCourses> teachersCoursesBL)
        {
            bool IsTeachersCoursesInserted = false;
            var teachersCourses = _mapper.Map<TeachersCourses>(teachersCoursesBL);
            IsTeachersCoursesInserted = AddTeacherCourses(teachersCourses);
            return IsTeachersCoursesInserted;
        }

        public bool UpdateTeachersCoursesBL(TeachersCoursesBL<TeachersCourses> teachersCoursesBL)
        {
            bool IsTeacherCourseUpdated = false;
            var teachersCourses = _mapper.Map<TeachersCourses>(teachersCoursesBL);
            IsTeacherCourseUpdated = UpdateTeachersCourses(teachersCourses);
            return IsTeacherCourseUpdated;
        }
        #endregion

    }
}

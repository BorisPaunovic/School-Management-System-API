using AutoMapper;
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
    public class CoursesSubjectsBusinessLogic: ICoursesSubjectsBusinessLogic
    {

        private readonly ICoursesSubjectsServices _coursesSubjectsServices;
        private readonly IMapper _mapper;
        public CoursesSubjectsBusinessLogic(ICoursesSubjectsServices coursesSubjectsServices, IMapper mapper)
        {
            this._coursesSubjectsServices = coursesSubjectsServices;
            this._mapper = mapper;
        }


        #region CourseSubject Functions

        public bool AddCourseSubject(CoursesSubjects coursesSubjects)
        {
            bool IsCourseSubjectInserted = false;
            IsCourseSubjectInserted = _coursesSubjectsServices.AddCourseSubject(coursesSubjects);
            return IsCourseSubjectInserted;
        }
        public List<CoursesSubjects> SelectAllCourses()
        {
            List<CoursesSubjects> CoursesSubjectsList = new List<CoursesSubjects>();
            CoursesSubjectsList = _coursesSubjectsServices.SelectAllCoursesSubjects();
            return CoursesSubjectsList;
        }
        public List<CoursesSubjects> SelectCoursesSubjectsById(int CoursesId)
        {
            List<CoursesSubjects> coursesSubjectsList = new List<CoursesSubjects>();
            coursesSubjectsList = _coursesSubjectsServices.SelectCoursesSubjectsById(CoursesId);
            return coursesSubjectsList;
        }
        public bool UpdateCoursesSubjects(CoursesSubjects coursesSubject)
        {
            bool IsCourseSubjectUpdated = false;
            IsCourseSubjectUpdated = _coursesSubjectsServices.UpdateCourseSubject(coursesSubject);
            return IsCourseSubjectUpdated;


        }
        #endregion



        #region CourseSubjectBL Functions
        public bool AddCourseSubjectBL(CoursesSubjectsBL<CoursesSubjects> coursesSubjectsBL)
        {
            bool IsCourseSubjectInserted = false;
            var courseSubject = _mapper.Map<CoursesSubjects>(coursesSubjectsBL);
            IsCourseSubjectInserted = _coursesSubjectsServices.AddCourseSubject(courseSubject);
            return IsCourseSubjectInserted;
        }
        public List<CoursesSubjectsBL<CoursesSubjects>> SelectAllCoursesBL()
        {
            List<CoursesSubjects> CoursesSubjectsList = new List<CoursesSubjects>();
            CoursesSubjectsList = _coursesSubjectsServices.SelectAllCoursesSubjects();
            var csBL= _mapper.Map<List<CoursesSubjectsBL<CoursesSubjects>>>(CoursesSubjectsList);
            return csBL;
        }
        public List<CoursesSubjectsBL<CoursesSubjects>> SelectCoursesSubjectsByIdBL(int CoursesId)
        {
            List<CoursesSubjects> coursesSubjectsList = new List<CoursesSubjects>();
            coursesSubjectsList = _coursesSubjectsServices.SelectCoursesSubjectsById(CoursesId);
            var csBL = _mapper.Map<List<CoursesSubjectsBL<CoursesSubjects>>>(coursesSubjectsList);
            return csBL;
        }
        public bool UpdateCoursesSubjectsBL(CoursesSubjectsBL<CoursesSubjects> coursesSubjectBL)
        {
            bool IsCourseSubjectUpdated = false;
            var coursesSubjects = _mapper.Map<CoursesSubjects>(coursesSubjectBL);
            IsCourseSubjectUpdated = _coursesSubjectsServices.UpdateCourseSubject(coursesSubjects);
           
            return IsCourseSubjectUpdated;


        }

        #endregion

    }
}

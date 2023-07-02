using AutoMapper;
using Microsoft.AspNetCore.Http;
using School.BusinessLogic.Interfaces;
using School.DataModels.Models;
using School.Services;
using School.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BusinessLogic
{
    public class CoursesBusinessLogic :ICourseBusinessLogic
    {


        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;


        public CoursesBusinessLogic(ICourseService courseService, IMapper mapper)
        {
            this._courseService = courseService;
            this._mapper = mapper;
        }

        #region Courses Functions


        public Courses SelectCourseByName(string CoursesName)
        {
            Courses courses = new Courses();
            courses = _courseService.SelectCourseByName(CoursesName);
            return courses;
        }
        public List<Courses> SelectAllCourses()
        {
            List<Courses> coursesList = new List<Courses>();
            coursesList = _courseService.SelectAllCourses();
            return coursesList;


        }
        public bool SaveCourse(Courses course)
        {
            bool IsCourseSaved = _courseService.SaveCourse(course);
            return IsCourseSaved;
        }
        public bool ValidateCourse(bool IsNameValid, bool IsDescriptionValid, bool _isClbSubjectsValid)
        {
            bool IsCourseValid = false;

            if (IsNameValid == true && IsDescriptionValid == true && _isClbSubjectsValid == true)
            {
                IsCourseValid = true;
            }
            return IsCourseValid;
        }

        public bool ValidateCoursename(string CourseName)
        {
            bool IsUnique = String.IsNullOrEmpty(SelectCourseByName(CourseName).CoursesName);
            bool isNameValid = false;
            if (String.IsNullOrEmpty(CourseName) == false && IsUnique == true)
            {
                isNameValid = true;
            }
            return isNameValid;
        }
        public bool ValidateCourseDescription(string CourseDescription)
        {
            bool isDescriptionValid = false;
            if (String.IsNullOrEmpty(CourseDescription) == false)
            {
                isDescriptionValid = true;
            }
            return isDescriptionValid;
        }

        public bool ValidateClbSubjects(object checkedListBox)
        {
            /*
            bool _isClbSubjectsValid = false;
            if (checkedListBox.CheckedItems.Count > 0)
            {
                _isClbSubjectsValid = true;
            }
            return _isClbSubjectsValid;
            */
            return true;
        }
        public bool UpdateCourse(Courses course)
        {
            bool IsCourseUpdated = false;
            IsCourseUpdated = _courseService.UpdateCourse(course);
            return IsCourseUpdated;
        }
        public bool DeleteCourse(int CourseId)
        {
            bool courseIsDeleted = false;
            courseIsDeleted = _courseService.DeleteCourse(CourseId);
            return courseIsDeleted;
        }

       

        


        #endregion





        #region CoursesBl Functions
        public CoursesBL<Courses> SelectCourseByNameBL(string CoursesName)
        {
            Courses course = new Courses();
            course = _courseService.SelectCourseByName(CoursesName);
            var courseBL = _mapper.Map<CoursesBL<Courses>>(course);
            if (courseBL.Data == null)
            {
                courseBL.Status = StatusCodes.Status500InternalServerError.ToString();
                courseBL.Message = "Error";
            }
            else
            {
                courseBL.Status = StatusCodes.Status200OK.ToString();
                courseBL.Message = "Sucsess";
            }
            return courseBL;
        }

        public List<CoursesBL<Courses>> SelectAllCoursesBL()
        {
            var courses = SelectAllCourses();
            var coursesBL = _mapper.Map<List<CoursesBL<Courses>>>(courses);

            foreach (var element in coursesBL)
            {
                if (coursesBL.FirstOrDefault().Data == null)
                {
                    element.Status = StatusCodes.Status500InternalServerError.ToString();
                    element.Message = "Error";
                }
                else
                {
                    element.Status = StatusCodes.Status200OK.ToString();
                    element.Message = "Sucsess";
                }
            }
            return coursesBL;

        }

        public bool SaveCourseBL(CoursesBL<Courses> courseBL)
        {
            var course = _mapper.Map<Courses>(courseBL);

            bool IsCourseSaved = SaveCourse(course);

            return IsCourseSaved;
        }

     
        public bool UpdateCourseBL(CoursesBL<Courses> courseBL)
        {
            var course = _mapper.Map<Courses>(courseBL);

            bool IsCourseUpdated = UpdateCourse(course);

            return IsCourseUpdated;
        }

        public bool DeleteCourseBL(int CourseId)
        {
            bool IsCourseDeleted = DeleteCourse(CourseId);

            return IsCourseDeleted;
        }

        public List<CoursesBL<Courses>> FilterByCourseNameBL(List<CoursesBL<Courses>> courses, string TextBox)
        {

            List<CoursesBL<Courses>> filterdCourses = new List<CoursesBL<Courses>>();
            foreach (var element in courses)
            {
                if (element.Data.CoursesName.ToLower().Contains(TextBox.ToLower()) == true)
                {
                    filterdCourses.Add(element);
                }


            }
            return filterdCourses;


          
        }
        public CoursesBL<Courses> SelectCourseBLByID(int CourseId)
        {
            Courses course = new Courses();
            course = _courseService.SelectCourseByID(CourseId);
            var courseBL = _mapper.Map<CoursesBL<Courses>>(course);
            if (courseBL.Data == null)
            {
                courseBL.Status = StatusCodes.Status500InternalServerError.ToString();
                courseBL.Message = "Error";
            }
            else
            {
                courseBL.Status = StatusCodes.Status200OK.ToString();
                courseBL.Message = "Sucsess";
            }
            return courseBL;
        }

        #endregion
    }
}

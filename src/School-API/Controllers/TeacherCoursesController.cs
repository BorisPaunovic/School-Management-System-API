using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.BusinessLogic;
using School.BusinessLogic.Interfaces;
using School.BusinessLogic.Interfaces.IJointClassesBusinessLogic;
using School.BusinessLogic.JointClassesBusinessLogic;
using School.DataModels.Models;
using System.Collections.Generic;

namespace School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherCoursesController : ControllerBase
    {
        private readonly ITeacherCoursesBusinessLogic _teacherCoursesBusinessLogic;
        private readonly ITeachersBusinessLogic _teachersBusinessLogic;

        public TeacherCoursesController( ITeacherCoursesBusinessLogic teacherCoursesBusinessLogic, ITeachersBusinessLogic teachersBusinessLogic)
        {
            this._teacherCoursesBusinessLogic = teacherCoursesBusinessLogic;
            _teachersBusinessLogic = teachersBusinessLogic;
        }
        [HttpGet]


        public IActionResult AddTeacherCourse()
        {
            return Ok("dfff");
        }
       
          [HttpPost]

        public IActionResult AddTeacher(TeachersCoursesBL<TeachersCourses> teachersBL)
        {
            try
            {
                var IsTeacherAdded = _teacherCoursesBusinessLogic.AddTeacherCoursesBL(teachersBL);
                return Ok(IsTeacherAdded);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }

        [HttpPut]

        public IActionResult UpdateTeacher(TeachersCoursesBL<TeachersCourses> teachersBL)
        {
            try
            {
                var IsTeacherUpdated = _teacherCoursesBusinessLogic.UpdateTeachersCoursesBL(teachersBL);
                return Ok(IsTeacherUpdated);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }


        [HttpGet]
        [Route("GetTjC")]
        public IActionResult GetllTeachersJoinCoursesBL()
        {
            try
            {
                var teachers = _teachersBusinessLogic.SelectAllTeachersJoinCoursesBL();



                return Ok(teachers);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }

        [HttpPost("FilterByTeacherName/{filter}")]
        public IActionResult FilterByTeacherBLName(List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> teachersBL, string filter)
        {
            try
            {
                var filterdCourse = _teachersBusinessLogic.FilterByTeacherBLName(teachersBL, filter);
                return Ok(filterdCourse);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }


        [HttpPost("FilterByCourseName/{filter}")]
        public IActionResult FilterByCourseName(List<TeachersJoinCoursesResaultBL<TeachersJoinCoursesResault>> teachersBL, string filter)
        {
            try
            {
                var filterdCourse = _teachersBusinessLogic.FilterByCourseNameBL(teachersBL, filter);
                return Ok(filterdCourse);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }





    }
}

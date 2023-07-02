using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.BusinessLogic.Interfaces.IJointClassesBusinessLogic;
using School.DataModels.Models;
using System.Collections.Generic;

namespace School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesSubjectsController : ControllerBase
    {


        
        private readonly ICoursesSubjectsBusinessLogic _coursesSubjectsBusinessLogic;

        public CoursesSubjectsController(ICoursesSubjectsBusinessLogic coursesSubjectsBusinessLogic)
        {
            this._coursesSubjectsBusinessLogic = coursesSubjectsBusinessLogic;
        }
       
        [HttpPost]

        public IActionResult AddCourseSubject(CoursesSubjectsBL<CoursesSubjects> coursesSubjectsBL)
        {
            try
            {
                var IsTeacherAdded = _coursesSubjectsBusinessLogic.AddCourseSubjectBL(coursesSubjectsBL);
                return Ok(IsTeacherAdded);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        
        [HttpPut]

        public IActionResult UpdateCoursesSubjects(CoursesSubjectsBL<CoursesSubjects> coursesSubjectsBL)
        {
            try
            {
                var IsTeacherUpdated = _coursesSubjectsBusinessLogic.UpdateCoursesSubjectsBL(coursesSubjectsBL);
                return Ok(IsTeacherUpdated);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }

        [HttpGet]

        public IActionResult SelectAllCoursesSubjects()
        {
            try
            {
                var coursesSubjectsBL = _coursesSubjectsBusinessLogic.SelectAllCoursesBL();
                return Ok(coursesSubjectsBL);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }


        [HttpGet("{CoursesId}")]

        public IActionResult SelectCoursesSubjectsById(int CoursesId)
        {
            try
            {
                var coursesSubjectsBL = _coursesSubjectsBusinessLogic.SelectCoursesSubjectsByIdBL(CoursesId);
                return Ok(coursesSubjectsBL);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        
        




    }
}

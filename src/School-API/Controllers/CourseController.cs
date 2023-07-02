using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.BusinessLogic.Interfaces;
using School.DataModels.Models;
using System.Collections.Generic;

namespace School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        
        private readonly ICourseBusinessLogic _courseBusinessLogic;

        public CourseController( ICourseBusinessLogic courseBusinessLogic)
        {
            this._courseBusinessLogic = courseBusinessLogic;
        }
        [HttpGet]
      
        public IActionResult GetAllCourses()
        {
            try
            {
                var countries = _courseBusinessLogic.SelectAllCoursesBL();



                return Ok(countries);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }

        
        [HttpGet("{Id}")]


      
        public IActionResult GetCourseById(int Id)
        {
            try
            {
                var courseBL = _courseBusinessLogic.SelectCourseBLByID(Id);
                return Ok(courseBL);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        
        [HttpGet("Name/{name}")]

        public IActionResult GetCoutryByName(string name)
        {
            try
            {
                var country = _courseBusinessLogic.SelectCourseByNameBL(name);
                return Ok(country);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpPost]

        public IActionResult AddCourse(CoursesBL<Courses> courseBL)
        {
            try
            {
                var IsCourseAdded = _courseBusinessLogic.SaveCourseBL(courseBL);
                return Ok(IsCourseAdded);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpDelete]

        public IActionResult DeleteCountry(int Id)
        {
            try
            {
                var country = _courseBusinessLogic.DeleteCourseBL(Id);
                return Ok(country);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpPut]
        public IActionResult UpdateCountry(CoursesBL<Courses> coursesBL)
        {

            try
            {
                var iscoursesUpdated = _courseBusinessLogic.UpdateCourseBL(coursesBL);
                return Ok(iscoursesUpdated);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }



        [HttpPost("FilterByCourseName/{filter}")]
        public IActionResult FilterByCountryName(List<CoursesBL<Courses>> courses, string filter)
        {
            try
            {
                var filterdCourse = _courseBusinessLogic.FilterByCourseNameBL(courses, filter);
                return Ok(filterdCourse);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
    }
}

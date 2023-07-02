using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.BusinessLogic.Interfaces.IJointClassesBusinessLogic;
using School.DataModels.Models;

namespace School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsCoursesController : ControllerBase
    {


        private readonly IStudentCoursesBusinessLogic _studentCoursesBusinessLogic;

        public StudentsCoursesController(IStudentCoursesBusinessLogic studentCoursesBusinessLogic)
        {
            this._studentCoursesBusinessLogic = studentCoursesBusinessLogic;
        }
       

        [HttpPost]

        public IActionResult AddSStudentCourse(StudentCoursesBL<StudentCourses> studentCourses)
        {
            try
            {
                var IsStudentCourse = _studentCoursesBusinessLogic.AddStudentCourseBL(studentCourses);
                return Ok(IsStudentCourse);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }

        [HttpPut]

        public IActionResult UpdateStudentCourses(StudentCoursesBL<StudentCourses> studentCourses)
        {
            try
            {
                var IsStudentCourses = _studentCoursesBusinessLogic.UpdateStudentCourseBL(studentCourses);
                return Ok(IsStudentCourses);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }

       
    }
}

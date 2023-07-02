using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.BusinessLogic.Interfaces;
using School.DataModels.Models;
using School.DataModels.Responce.Students;
using System.Collections.Generic;
using System.Reflection;

namespace School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsBusinessLogic _studentBusinessLogic;

        public StudentsController(IStudentsBusinessLogic studentsBusinessLogic)
        {
            this._studentBusinessLogic = studentsBusinessLogic;
        }
        [HttpGet]
       
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = _studentBusinessLogic.SelectAllUsersBL();



                return Ok(students);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }


        [HttpGet("{Id}")]



        public IActionResult GetStudentById(int Id)
        {
            try
            {
                var courseBL = _studentBusinessLogic.SelectStudentBLById(Id);
                return Ok(courseBL);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }

        [HttpGet("Name/{name}")]

        public IActionResult GetStudentsByName(string name)
        {
            try
            {
                var student = _studentBusinessLogic.SelectStudentBLByName(name);
                return Ok(student);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpPost]

        public IActionResult AddStudent(StudentsBL<Students> courseBL)
        {
            try
            {
                var IsCourseAdded = _studentBusinessLogic.SaveStudentBL(courseBL);
                return Ok(IsCourseAdded);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpDelete]

        public IActionResult DeleteStudent(int Id)
        {
            try
            {
                var country = _studentBusinessLogic.DeleteStudentBL(Id);
                return Ok(country);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpPut]
        public IActionResult UpdateStudent(StudentsBL<Students> studentBL)
        {
          
            try
            {
                var iscoursesUpdated = _studentBusinessLogic.UpdateStudentBL(studentBL);
                return Ok(iscoursesUpdated);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }



        [HttpPost("FilterByCourseName/{filter}")]
        public IActionResult FilterByCourseNameBL(List<StudentsResaultBL<StudentsResault>> studentsBl, string filter)
        {
            try
            {
                var filterdCourse = _studentBusinessLogic.FilterByCourseNameBL(studentsBl, filter);
                return Ok(filterdCourse);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }


        [HttpPost("FilterByStudentName/{filter}")]
        public IActionResult FilterByStudentName(List<StudentsResaultBL<StudentsResault>> studentsBl, string filter)
        {
            try
            {
                var filterdCourse = _studentBusinessLogic.FilterByStudentNameBL(studentsBl, filter);
                return Ok(filterdCourse);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }


        [HttpGet("LastStudent")]

        public IActionResult GetLastStudent()
        {
            try
            {
                var country = _studentBusinessLogic.SelectLastStudentBL();
                return Ok(country);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }

        
    }
}

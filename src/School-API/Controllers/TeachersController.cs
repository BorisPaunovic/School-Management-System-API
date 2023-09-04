using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.BusinessLogic.Interfaces;
using School.DataModels.Models;
using System.Collections.Generic;

namespace School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeachersBusinessLogic _teachersBusinessLogic;

        public TeachersController(ITeachersBusinessLogic teachersBusinessLogic)
        {
            this._teachersBusinessLogic = teachersBusinessLogic;
        }
        [HttpGet]
      
        public IActionResult GetAllteachers()
        {
            try
            {
                var students = _teachersBusinessLogic.SelectAllTeachersBL();



                return Ok(students);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }

       



        [HttpGet("{Id}")]
        public IActionResult GetTeacherById(int Id)
        {
            try
            {
                var teacherBl = _teachersBusinessLogic.SelectTeacherBLByID(Id);
                return Ok(teacherBl);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }

        [HttpGet("Name/{name}")]

        public IActionResult GetTeacherByName(string name)
        {
            try
            {
                var teacher = _teachersBusinessLogic.SelectTeacherBLByName(name);
                return Ok(teacher);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpPost]

        public IActionResult AddTeacher(TeachersBL<Teachers> teachersBL)
        {
            try
            {
                var IsTeacherAdded = _teachersBusinessLogic.SaveTeacherBL(teachersBL);
                return Ok(IsTeacherAdded);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpDelete("{Id}")]

        public IActionResult DeleteTeacher(int Id)
        {
            try
            {
                var IsTeacherDeleted = _teachersBusinessLogic.DeleteTeacheBL(Id);
                return Ok(IsTeacherDeleted);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpPut]
        public IActionResult UpdateTeacehr(TeachersBL<Teachers> teacherBL)
        {

            try
            {
                var isTeacherUpdated = _teachersBusinessLogic.UpdateTeacherBL(teacherBL);
                return Ok(isTeacherUpdated);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }



        
    }
}

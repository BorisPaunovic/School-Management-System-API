using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.BusinessLogic.Interfaces;
using School.BusinessModels.Responce.Students;
using School.DataModels.Models;
using System.Collections.Generic;

namespace School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {

        private readonly ISubjectsBusinessLogic _subjectsBusinessLogic;


        public SubjectsController(ISubjectsBusinessLogic subjectsBusinessLogic)
        {

            this._subjectsBusinessLogic = subjectsBusinessLogic;
        }

        [HttpGet]
        
        
        public IActionResult GetAllSubjects()
        {
            try
            {
                var countries = _subjectsBusinessLogic.SelectAllSubjectsBL();



                return Ok(countries);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        
        [HttpGet("{Id}")]

        public IActionResult GetCoutryById(int Id)
        {
            try
            {
                var subject = _subjectsBusinessLogic.SelectSubjectBLById(Id);
                return Ok(subject);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        
        [HttpGet("Name/{name}")]

        public IActionResult GetSubjectByName(string name)
        {
            try
            {
                var country = _subjectsBusinessLogic.SelectSubjectBLByName(name);
                return Ok(country);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpPost]

        public IActionResult AddCountry(SubjectsBL<Subjects> subjectsBL)
        {
            try
            {
                var subjects = _subjectsBusinessLogic.SaveSubjectBL(subjectsBL);
                return Ok(subjects);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpDelete("{Id}")]

        public IActionResult DeleteCountry(int Id)
        {
            try
            {
                var country = _subjectsBusinessLogic.DeleteSubjectBL(Id);
                return Ok(country);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpPut]
        public IActionResult UpdateCountry(SubjectsBL<Subjects> subjectsBL)
        {

            try
            {
                var subjects = _subjectsBusinessLogic.UpdateSubjectBL(subjectsBL);
                return Ok(subjects);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }



        [HttpPost("FilterByCountryName/{filter}")]
        public IActionResult FilterByCountryName(List<SubjectsBL<Subjects>> subjectsBLs, string filter)
        {
            try
            {
                var filterdSubject = _subjectsBusinessLogic.FilterBySubjectBLName(subjectsBLs, filter);
                return Ok(filterdSubject);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
      

    }
}

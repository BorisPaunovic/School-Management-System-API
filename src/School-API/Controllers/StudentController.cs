using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.BusinessLogic;
using School.BusinessLogic.Interfaces;
using School.BusinessModels.Responce.Students;
using School.DataModels.Models;
using School.Services.Interfaces;
using System.Collections.Generic;

namespace School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentBusinessLogic _studentBusinessLogic;
        private readonly ICountriesBusinessLogic _countriesBL;
        public List<GetStudentResponce> _getStudentRespopnces;
      
        public StudentController(IStudentBusinessLogic studentBusinessLogic, ICountriesBusinessLogic countriesBL)
        {
            this._studentBusinessLogic = studentBusinessLogic;
            this._countriesBL = countriesBL;
        }


        [HttpGet]

        public IActionResult GetAllStudents()
        {
            try
            {
                _getStudentRespopnces = _studentBusinessLogic.GetAllStudents();
                return Ok(_getStudentRespopnces);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpGet]
        [Route("Test")]
        public IActionResult Test()
        {
            try
            {
                List<CountriesBL<Countries>> countries = _countriesBL.SelectAllCountryesBL();
                _getStudentRespopnces = _studentBusinessLogic.GetAllStudents();
                return Ok(countries);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
    }
}

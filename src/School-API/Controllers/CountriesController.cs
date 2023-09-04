using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.BusinessLogic.Interfaces;
using School.BusinessModels.Responce.Students;
using School.DataModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace School_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
     
        private readonly ICountriesBusinessLogic _countriesBL;
        public List<GetStudentResponce> _getStudentRespopnces;

        public CountriesController( ICountriesBusinessLogic countriesBL)
        {
           
            this._countriesBL = countriesBL;
        }

        [HttpGet]
        
        public IActionResult GetAllStudents()
        {
            try
            {
                var countries = _countriesBL.SelectAllCountryesBL();
             
              

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
                var country = _countriesBL.SelectCountryBLByID(Id);
                return Ok(country);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpGet ("Name/{name}")]

        public IActionResult GetCoutryByName(string name)
        {
            try 
            {
                var country = _countriesBL.SelectCountryBLByName(name);
                return Ok(country);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpPost]

        public IActionResult AddCountry(CountriesBL<Countries> countriesBL)
        {
            try
            {
                var country = _countriesBL.SaveCountryBL(countriesBL);
                return Ok(country);
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
                var country = _countriesBL.DeleteCountryBL(Id);
                return Ok(country);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }
        [HttpPut]
        public IActionResult UpdateCountry(CountriesBL<Countries> countriesBL)
        {

            try
            {
                var country = _countriesBL.UpdateCountryBL(countriesBL);
                return Ok(country);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }



        [HttpPost("FilterByCountryName/{filter}")]
        public IActionResult FilterByCountryName(List<CountriesBL<Countries>> countries, string filter)
        {
            try
            {
                var filterdCountry = _countriesBL.FilterByCountryNameBL(countries, filter);
                return Ok(filterdCountry);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
        [HttpPost("FilterByCountryIso/{filter}")]
        public IActionResult FilterByIso(List<CountriesBL<Countries>> countries, string filter)
        {
            try
            {
                var filterdCountry = _countriesBL.FilterByIsoBL(countries, filter);
                return Ok(filterdCountry);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
    }
}

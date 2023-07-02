using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.BusinessLogic.Interfaces;
using School.BusinessModels.Responce.Students;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IStudentBusinessLogic studentBusinessLogic;
        private List<GetStudentResponce> _students;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStudentBusinessLogic studentBusinessLogic)
        {
            _logger = logger;
            this.studentBusinessLogic = studentBusinessLogic;
        }

        [HttpGet("weather")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
       
        [HttpGet]
        
        public IActionResult GetAllStudents()
        {

            _students = studentBusinessLogic.GetAllStudents();
            return Ok(_students);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conceptual.Polymorphism.DataTransferObjects.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Conceptual.Polymorphism.Controllers
{
    [ApiController]
    [Route("persons")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public PersonController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return new List<Person>() {
                new Employee
                {
                    FirstName = "Wasutan",
                    LastName = "Kitijerapat",
                    Company = "Chiang mai company",
                },
                new Student
                {
                    FirstName = "Wasutan",
                    LastName = "Kitijerapat",
                    College = "Chiang mai university",
                }
            };
        }

        [HttpPost]
        public Person Post([FromBody] Person person)
        {
            return person;
        }
    }
}

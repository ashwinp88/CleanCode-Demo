using Microsoft.AspNetCore.Mvc;
using AwesomeApplication.Domain;
using System.Collections.Generic;
using System.Linq;

namespace DataStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private static IEnumerable<Person> _people = new List<Person>()
        {
            new Person() {Id = 1, FirstName = "Bruce", LastName = "Banner", StartDate = new System.DateTime(2021, 1, 1), EndDate = new System.DateTime(2021, 6, 30)},
            new Person() {Id = 2, FirstName = "Peter", LastName = "Parker", StartDate = new System.DateTime(2021, 7, 1), EndDate = new System.DateTime(2021, 12, 31)},
            new Person() {Id = 3, FirstName = "Natasha", LastName = "Romanov", StartDate = new System.DateTime(2021, 1, 1), EndDate = new System.DateTime(2021, 12, 31)}
        };

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _people;
        }

        [HttpGet("{id}")]
        public Person Get(int Id)
        {
            return _people.FirstOrDefault(p => p.Id == Id);
        }

       

    }
}

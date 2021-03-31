using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Collections.Generic;
using System.Linq;

namespace DataStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public static IEnumerable<Person> _people = new List<Person>()
        {
            new Person() {Id = 1, FirstName = "Bruce", LastName = "Banner"},
            new Person() {Id = 2, FirstName = "Peter", LastName = "Parker"},
            new Person() {Id = 3, FirstName = "Natasha", LastName = "Romanov"}
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

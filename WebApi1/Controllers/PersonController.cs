using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi1.Model;

namespace WebApi1.Controllers
{
    [Produces("application/json")]
    [Route("api/Person")]
    public class PersonController : Controller
    {
        public readonly IPersonRepository _persons;

        public PersonController(IPersonRepository person)
        {
            _persons = person;
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            return _persons.GetAll();
        }   

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult Get(string id)
        {
            var person = _persons.FindById(id);

            return new ObjectResult(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            var id = Guid.NewGuid().ToString();
            person.Id = id;

            _persons.Add(person);

            return CreatedAtRoute("GetById", new { id = person.Id}, person);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Person person)
        {
            person.Id = id;
            _persons.Update(person);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _persons.Delete(id);

            return new NoContentResult();
        }
    }
}
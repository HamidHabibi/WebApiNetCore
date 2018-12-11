using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace WebApi1.Model
{
    public class PersonRepository : IPersonRepository
    {
        private static ConcurrentDictionary<string, Person> _person =
            new ConcurrentDictionary<string, Person>();

        public PersonRepository()
        {
            Add(new Person() { Id = Guid.NewGuid().ToString(), FullName = "Hamid", Etebar = 12000.25M });
        }
        public void Add(Person person)
        {
            _person[person.Id] =  person;
        }

        public Person Delete(string id)
        {
            Person person = FindById(id);

            _person.TryRemove(id, out person);

            return person;
        }

        public Person FindById(string id)
        {
            Person person;
            _person.TryGetValue(id, out person);

            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            return _person.Values;
        }

        public void Update(Person person)
        {
            _person[person.Id] = person;
        }
    }
}

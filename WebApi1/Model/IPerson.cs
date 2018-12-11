using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Model
{
    public interface IPersonRepository
    {
        void Add(Person person);
        Person FindById(string id);
        void Update(Person person);
        Person Delete(string id);
        IEnumerable<Person> GetAll();
    }
}

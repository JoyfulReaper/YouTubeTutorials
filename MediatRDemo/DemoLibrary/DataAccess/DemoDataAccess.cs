using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.DataAccess;
public class DemoDataAccess : IDataAccess
{
    public DemoDataAccess()
    {
        people.Add(new PersonModel { Id = 1, FirstName = "Tim", LastName = "Corey" });
        people.Add(new PersonModel { Id = 2, FirstName = "Sue", LastName = "Storm" });
    }

    private List<PersonModel> people = new();

    public List<PersonModel> GetPeople()
    {
        return people;
    }

    public PersonModel InsertPerson(string firstName, string lastName)
    {
        PersonModel person = new PersonModel { LastName = lastName, FirstName = firstName };
        person.Id = people.Max(p => p.Id) + 1;
        people.Add(person);

        return person;
    }
}

using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListPeople()
        {
            List<PersonModel> people = new List<PersonModel>();

            people.Add(new PersonModel { FirstName = "Tim", LastName = "Corey", Age = 38 });
            people.Add(new PersonModel { FirstName = "Joe", LastName = "Smith", Age = 56 });
            people.Add(new PersonModel { FirstName = "Sarah", LastName = "Conner", Age = 25 });

            return View(people);
        }
    }
}
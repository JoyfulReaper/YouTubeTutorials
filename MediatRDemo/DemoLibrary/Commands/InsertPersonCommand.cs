using DemoLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Commands;

public record InsertPersonCommand(string FirstName, string LastName) : IRequest<PersonModel>;

//public class InsertPersonCommandClass : IRequest<PersonModel>
//{
//    public InsertPersonCommandClass(string firstName, string lastName)
//    {
//        FirstName = firstName;
//        LastName = lastName;
//    }

//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//}

using System;
using Conceptual.Polymorphism.Converters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Conceptual.Polymorphism.DataTransferObjects.Person
{
    public abstract class Person 
    {
        public abstract string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class Student : Person
    {
        public override string Role { get; set; } = "Student";
        public string College { get; set; }
    }

    public class Employee : Person
    {
        public override string Role { get; set; } = "Employee";
        public string Company { get; set; }
    }
}

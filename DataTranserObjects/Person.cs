using System;
using System.Text.Json.Serialization;

namespace Conceptual.Polymorphism.DataTransferObjects.Person
{
    public abstract class Person 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class Student : Person
    {
        public string College { get; set; }
    }

    public class Employee : Person
    {
        public string Company { get; set; }
    }
}

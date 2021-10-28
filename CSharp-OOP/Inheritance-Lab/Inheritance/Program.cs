using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Niki");
            var student = new Student("Stoyan", "SoftUni");
            var employee = new Employee("Victor");

            person.Sleep();
            student.Sleep();
            employee.Sleep();


        }
    }
}

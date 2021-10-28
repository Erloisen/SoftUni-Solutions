using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Employee : Person
    {
        public Employee(string name)
            : base (name)
        {
            
        }
        public string Company { get; set; }
    }
}

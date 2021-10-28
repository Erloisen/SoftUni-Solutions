using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Student : Person, ICanRead, ICanWrite
    {
        public Student(string name, string school)
            : base(name)
        {
            this.School = school;
        }
        public string School { get; set; }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            throw new NotImplementedException();
        }
    }
}

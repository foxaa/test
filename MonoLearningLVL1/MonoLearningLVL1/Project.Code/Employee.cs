using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code
{
    public abstract class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        protected Employee(string name, string lastName, int age)
        {
            FirstName = name;
            LastName = lastName;
            Age = age;       
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        protected Employee(int id,string name, string lastName, int age)
        {
            this.Id = id;
            this.FirstName = name;
            this.LastName = lastName;
            this.Age = age;
        }

        public Employee() { }
    }
}

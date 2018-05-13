using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Models
{
    public class Developer:Employee
    {
        public string Project { get; set; }
        public bool IsStudent { get; set; }
        public Developer(int id,string name, string lastName, int age, string project, bool isStudent)
           : base(id,name, lastName, age)
        {
            this.Project = project;
            this.IsStudent = isStudent;
        }
    }
}

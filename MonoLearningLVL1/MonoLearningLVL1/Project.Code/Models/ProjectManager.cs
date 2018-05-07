using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Models
{
    public class ProjectManager:Employee
    {
        public string Project { get; set; }
        public ProjectManager(string name, string lastName, int age, string project)
           : base(name, lastName, age)
        {
            this.Project = project;
        }
    }
}

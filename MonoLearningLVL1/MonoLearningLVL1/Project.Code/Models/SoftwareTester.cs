using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Models
{
    public class SoftwareTester:Employee
    {
        public string Project { get; set; }
        public bool UsesAutomatedTests { get; set; }
        public SoftwareTester(int id,string name, string lastName, int age, string project, bool usesAutomatedTests)
            : base(id,name, lastName, age)
        {
            this.Project = project;
            this.UsesAutomatedTests = usesAutomatedTests;
        }

        public SoftwareTester() { }
    }
}

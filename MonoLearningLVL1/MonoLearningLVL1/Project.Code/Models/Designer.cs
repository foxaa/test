using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Models
{
    public class Designer:Employee
    {
        public string Project { get; set; }
        public bool CanDraw { get; set; }
        public Designer(int id,string name, string lastName, int age, string project, bool canDraw)
            : base(id,name, lastName, age)
        {
            this.Project = project;
            this.CanDraw = canDraw;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Models
{
    public class CEO:Employee
    {
        public int CeoYears { get; set; }

        public CEO(string name, string lastName, int age,int years)
            :base(name,lastName,age)
        {
            this.CeoYears = years;
        }
    }
}

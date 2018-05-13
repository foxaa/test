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

        public CEO(int id,string name, string lastName, int age,int years)
            :base(id,name,lastName,age)
        {
            this.CeoYears = years;
        }
    }
}

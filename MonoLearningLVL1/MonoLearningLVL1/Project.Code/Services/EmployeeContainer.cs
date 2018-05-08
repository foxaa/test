using Project.Code.Models;
using Project.Code.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code
{
    public sealed class EmployeeContainer:BaseCRUD
    {
        private static EmployeeContainer instance;
        private EmployeeContainer() { }

        public static EmployeeContainer Inst
        {
            get
            {
                if(instance==null)
                {
                    instance = new EmployeeContainer();
                }
                return instance;
            }
        }

        public new void AddEmployee(Employee employee)
        {
            base.AddEmployee(employee);
        }

        public new void DeleteEmployee(Employee employee)
        {
            base.DeleteEmployee(employee);
        }

        public new void AddCEO(Employee employee)
        {
            base.AddCEO(employee);
        }

        public new List<Employee> GetEmployees()
        {
            return base.GetEmployees();
        }
    }
}

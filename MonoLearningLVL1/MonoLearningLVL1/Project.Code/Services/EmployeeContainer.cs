using Project.Code.Models;
using Project.Code.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code
{
    public class EmployeeContainer
    {
        private static EmployeeContainer instance;
        private List<Employee> EmployeeList =new List<Employee>();

        private EmployeeContainer()
        {
        }

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

        public void AddEmployee(Employee employee)
        {
            EmployeeList.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            EmployeeList.Remove(employee);
        }

        public void AddCEO(Employee employee)
        {
            EmployeeList.Add(employee);
        }

        public List<Employee> GetEmployees()
        {
            return EmployeeList.ToList();
        }
    }
}

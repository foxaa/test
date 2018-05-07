using Project.Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code
{
    public class EmployeeContainer
    {
        public bool ceoExists = false;
        List<Employee> Employees = new List<Employee>();
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

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        public void AddCEO(Employee employee)
        {
            if (!ceoExists)
            {
                Employees.Add(employee);
                ceoExists = true;
            }
            else
                Console.WriteLine("There can only be one CEO");
        }

        public List<Employee> GetEmployees()
        {
            return Employees;
        }
    }
}

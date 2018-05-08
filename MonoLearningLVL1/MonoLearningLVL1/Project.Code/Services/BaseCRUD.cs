using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Services
{
    public abstract class BaseCRUD
    {

        private bool ceoExists = false;
        List<Employee> Employees = new List<Employee>();

        protected void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        protected List<Employee> GetEmployees()
        {
            return Employees;
        }

        protected void DeleteEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        protected void AddCEO(Employee employee)
        {
            if (!ceoExists)
            {
                Employees.Add(employee);
                ceoExists = true;
            }
            else
                Console.WriteLine("There can only be one CEO");
        }

    }
}

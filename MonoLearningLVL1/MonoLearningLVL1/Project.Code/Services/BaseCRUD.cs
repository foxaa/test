using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Services
{
    public abstract class BaseCRUD
    {
        private static bool ceoExists = false;
        private readonly EmployeeContainer storage;

        protected BaseCRUD()
        {
            storage = EmployeeContainer.Inst;
        }

        protected void AddEmployee(Employee employee)
        {
            storage.AddEmployee(employee);
        }

        protected List<Employee> GetEmployees()
        {
            return storage.GetEmployees();
        }

        protected void DeleteEmployee(Employee employee)
        {
            storage.DeleteEmployee(employee);
        }
    }
}

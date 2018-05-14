using Project.Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Services
{
    public class CeoService:BaseCRUD
    {
        private static bool ceoExists = false;

        public new void AddEmployee(Employee ceo)
        {
            Validation validation = new Validation();
            EmployeeIdGeneratorService IdGenerator = EmployeeIdGeneratorService.Inst;
            string ceoYears = String.Empty;

            do
            {
                Console.Write("Enter years of being CEO:");
                ceoYears = Console.ReadLine();
                validation.CheckIntegerInput(ceoYears);
            } while (!validation.inputIsValid);
            Int32.TryParse(ceoYears, out int ceoYearsInt);
            var id = IdGenerator.IncId();
            Employee employee = new CEO(id, ceo.FirstName, ceo.LastName, ceo.Age, ceoYearsInt);
            if (!ceoExists)
            {
                base.AddEmployee(employee);
                ceoExists = true;
            }
            else
                Console.WriteLine("There can only be one CEO");
            
        }

        public void GetCeoList(string operation)
        {
            EmployeeContainer employeeContainer = EmployeeContainer.Inst;
            List<Employee> employees = employeeContainer.GetEmployees();

            foreach (CEO c in employees.OfType<CEO>())
            {
                Console.WriteLine(c.Id + ":" + c.FirstName + "," + c.LastName + "," + c.Age + ","
                    + c.CeoYears);
            }
        }


    }
}

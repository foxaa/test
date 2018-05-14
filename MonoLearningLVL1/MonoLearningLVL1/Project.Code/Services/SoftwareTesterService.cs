using Project.Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Services
{
    public class SoftwareTesterService:BaseCRUD
    {
        public new void AddEmployee(Employee emp)
        {
            string projectName = String.Empty;
            string checkBool = String.Empty;
            Validation validation = new Validation();
            EmployeeIdGeneratorService IdGenerator = EmployeeIdGeneratorService.Inst;
            bool boolValue = false;

            do
            {
                Console.Write("Enter project name:");
                projectName = Console.ReadLine();
                validation.CheckInput(projectName);
            } while (!validation.inputIsValid);
            do
            {
                Console.Write("Is tester using automated tests?");
                checkBool = Console.ReadLine();
                boolValue = validation.CheckBoolInput(checkBool);
            }
            while (!validation.inputIsValid);
            var id = IdGenerator.IncId();
            Employee employee = new SoftwareTester(id, emp.FirstName, emp.LastName, emp.Age, projectName, boolValue);
            base.AddEmployee(employee);
        }

        public void GetStList(string operation)
        {
            EmployeeContainer employeeContainer = EmployeeContainer.Inst;
            List<Employee> employees = employeeContainer.GetEmployees();

            foreach (SoftwareTester s in employees.OfType<SoftwareTester>())
            {
                Console.WriteLine(s.Id + ":" + s.FirstName + "," + s.LastName + "," + s.Age + ","
                    + s.Project + "," + s.UsesAutomatedTests);
            }
        }
    }
}

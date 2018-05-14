using Project.Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Services
{
    public class DeveloperService:BaseCRUD
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
                Console.Write("Is developer a student?");
                checkBool = Console.ReadLine();
                boolValue = validation.CheckBoolInput(checkBool);
            }
            while (!validation.inputIsValid);
            var id = IdGenerator.IncId();
            Employee employee = new Developer(id, emp.FirstName, emp.LastName, emp.Age, projectName, boolValue);
            base.AddEmployee(employee);
        }

        public void GetDevList(string operation)
        {
            EmployeeContainer employeeContainer = EmployeeContainer.Inst;
            List<Employee> employees = employeeContainer.GetEmployees();

            foreach (Developer d in employees.OfType<Developer>())
            {
                Console.WriteLine(d.Id + ":" + d.FirstName + "," + d.LastName + "," + d.Age + ","
                    + d.Project + "," + d.IsStudent);
            }
        }
    }
}

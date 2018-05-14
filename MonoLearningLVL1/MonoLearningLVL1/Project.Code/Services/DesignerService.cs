using Project.Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Services
{
    public class DesignerService:BaseCRUD
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
                Console.Write("Can the designer draw?");
                checkBool = Console.ReadLine();
                boolValue = validation.CheckBoolInput(checkBool);
            }
            while (!validation.inputIsValid);
            var id = IdGenerator.IncId();
            Employee employee = new Designer(id, emp.FirstName, emp.LastName, emp.Age, projectName, boolValue);
            base.AddEmployee(employee);
        }

        public void GetDsnrList(string operation)
        {
            EmployeeContainer employeeContainer = EmployeeContainer.Inst;
            List<Employee> employees = employeeContainer.GetEmployees();

            foreach (Designer d in employees.OfType<Designer>())
            {
                Console.WriteLine(d.Id + ":" + d.FirstName + "," + d.LastName + "," + d.Age + ","
                    + d.Project + "," + d.CanDraw);
            }
        }
    }
}

using Project.Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Services
{
    public class ProjectManagerService:BaseCRUD
    {
        public new void AddEmployee(Employee emp)
        {
            string projectName = String.Empty;
            Validation validation = new Validation();
            EmployeeIdGeneratorService IdGenerator = EmployeeIdGeneratorService.Inst;

            do
            {
                Console.Write("Enter project name:");
                projectName = Console.ReadLine();
                validation.CheckInput(projectName);
            } while (!validation.inputIsValid);
            var id = IdGenerator.IncId();
            Employee employee = new ProjectManager(id, emp.FirstName, emp.LastName, emp.Age, projectName);
            base.AddEmployee(employee);
        }

        public void GetPmList(string operation)
        {
            EmployeeContainer employeeContainer = EmployeeContainer.Inst;
            List<Employee> employees = employeeContainer.GetEmployees();

            foreach (ProjectManager p in employees.OfType<ProjectManager>())
            {
                Console.WriteLine(p.Id + ":" + p.FirstName + "," + p.LastName + "," + p.Age + ","
                    + p.Project);
            }
        }
    }
}

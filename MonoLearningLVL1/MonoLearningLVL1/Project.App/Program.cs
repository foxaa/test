using Project.Code;
using Project.Code.Models;
using Project.Code.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Validation validation = new Validation();
            string operation = String.Empty;

            bool isDisplay = false;
            Help();
            do
            {
                isDisplay = false;
                Console.Write("Insert command:");
                operation = Console.ReadLine();
                validation.CheckCommand(operation);
                if (validation.isHelpCommand) { Help(); }
                else if(validation.isAddCommand) { Add(); }
                else if(validation.isRoleListCommand) { RoleList(operation); }
                else if(validation.isRemoveCommand) { Remove(); }
                else if(validation.isListCommand) { List(); }
                else if (validation.isDisplayCommand)
                {
                    Display();
                }
            }
            while (!isDisplay);
        }

        public static void Remove()
        {
            EmployeeContainer employeeContainer = EmployeeContainer.Inst;
            List<Employee> employees = employeeContainer.GetEmployees();
            Validation validation = new Validation();

            string id = String.Empty;

            do
            {
                Console.Write("Enter id of employee you want to delete:");
                id = Console.ReadLine();
                validation.CheckIntegerInput(id);
            } while (!validation.inputIsValid);
            Int32.TryParse(id, out int intId);
            for (int i = employees.Count-1; i >=0; i--)
            {
                if (employees[i].Id == intId)
                {
                    employeeContainer.DeleteEmployee(employees[i]);
                    Console.WriteLine("Employee deleted");
                }
            }
        }

        public static void RoleList(string operation)
        {
            FactoryService factoryService = new FactoryService();
            factoryService.GetRoleList(operation);
        }

        public static void List()
        {
            EmployeeContainer employeeContainer = EmployeeContainer.Inst;
            List<Employee> employees = employeeContainer.GetEmployees();

            foreach (Employee emp in employees)
            {
                if (emp.GetType() == typeof(Developer))
                {
                    Console.WriteLine(emp.Id + ":" + Roles.Developer + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                }
                else if (emp.GetType() == typeof(ProjectManager))
                {
                    Console.WriteLine(emp.Id + ":" + Roles.ProjectManager + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                }
                else if (emp.GetType() == typeof(SoftwareTester))
                {
                    Console.WriteLine(emp.Id + ":" + Roles.SoftwareTester + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                }
                else if (emp.GetType() == typeof(Designer))
                {
                    Console.WriteLine(emp.Id + ":" + Roles.Designer + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                }
            }
        }

        public static void Display()
        {
            EmployeeContainer employeeContainer = EmployeeContainer.Inst;
            List<Employee> employees = employeeContainer.GetEmployees();
            Console.WriteLine("Employees in system:");
            string roleType = String.Empty;
            foreach(Employee emp in employees)
            {
                if(emp.GetType() == typeof(Developer))
                    Console.WriteLine(emp.Id + ":" + Roles.Developer + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                else if(emp.GetType() == typeof(CEO))
                    Console.WriteLine(emp.Id + ":" + Roles.CEO + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                else if(emp.GetType() == typeof(SoftwareTester))
                    Console.WriteLine(emp.Id + ":" + Roles.SoftwareTester + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                else if (emp.GetType() == typeof(Designer))
                    Console.WriteLine(emp.Id + ":" + Roles.Designer + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                else if (emp.GetType() == typeof(ProjectManager))
                    Console.WriteLine(emp.Id + ":" + Roles.ProjectManager + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
            }
        }

        public static void Help()
        {
            var availableCommands = Commands.Add + ","+ Commands.Display + "," + Commands.Help + "," +
                Commands.List + "," + Commands.Remove;

            Console.WriteLine("Available commands:" + availableCommands);
        }

        public static void Add()
        {
            string name = String.Empty;
            string lastName = String.Empty;
            string age = String.Empty;
            string role = String.Empty;

            Validation validation = new Validation();
            FactoryService factoryService = new FactoryService();

            do
            {
                Console.Write("Add:");
                role = Console.ReadLine();
                validation.CheckRoleInput(role);
            } while (!validation.inputIsValid);
            do
            {
                Console.Write("Enter name:");
                name = Console.ReadLine();
                validation.CheckInput(name);
            } while (!validation.inputIsValid);
            do
            {
                Console.Write("Enter last name:");
                lastName = Console.ReadLine();
                validation.CheckInput(lastName);
            } while (!validation.inputIsValid);
            do
            {
                Console.Write("Enter age:");
                age = Console.ReadLine();
                validation.CheckIntegerInput(age);
            } while (!validation.inputIsValid);
            var serv = factoryService.GetServiceForAdd(role);
            if(serv.GetType() == typeof(CeoService))
            {
                var service = (CeoService)serv;
                Employee employee = new CEO();
                employee.FirstName = name;
                employee.LastName = lastName;
                employee.Age = Int32.Parse(age);
                service.AddEmployee(employee);
            }
            else if(serv.GetType() == typeof(DeveloperService))
            {
                var service = (DeveloperService)serv;
                Employee employee = new Developer();
                employee.FirstName = name;
                employee.LastName = lastName;
                employee.Age = Int32.Parse(age);
                service.AddEmployee(employee);
            }
            else if (serv.GetType() == typeof(DesignerService))
            {
                var service = (DesignerService)serv;
                Employee employee = new Designer();
                employee.FirstName = name;
                employee.LastName = lastName;
                employee.Age = Int32.Parse(age);
                service.AddEmployee(employee);
            }
            else if (serv.GetType() == typeof(ProjectManagerService))
            {
                var service = (ProjectManagerService)serv;
                Employee employee = new ProjectManager();
                employee.FirstName = name;
                employee.LastName = lastName;
                employee.Age = Int32.Parse(age);
                service.AddEmployee(employee);
            }
            else if (serv.GetType() == typeof(SoftwareTesterService))
            {
                var service = (SoftwareTesterService)serv;
                Employee employee = new SoftwareTester();
                employee.FirstName = name;
                employee.LastName = lastName;
                employee.Age = Int32.Parse(age);
                service.AddEmployee(employee);
            }
        }
    }
}

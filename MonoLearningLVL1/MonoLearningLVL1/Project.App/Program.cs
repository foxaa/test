using Project.Code;
using Project.Code.Models;
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
            do
            {
                isDisplay = false;
                Help();
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

            string lastName = String.Empty;

            do
            {
                Console.Write("Enter last name of employee you want to delete:");
                lastName = Console.ReadLine();
                validation.CheckInput(lastName);
            } while (!validation.inputIsValid);

            for (int i = employees.Count-1; i >=0; i--)
            {
                if (employees[i].LastName == lastName)
                {
                    employeeContainer.DeleteEmployee(employees[i]);
                    Console.WriteLine("Employee deleted");
                }
            }
        }

        public static void RoleList(string operation)
        {
            EmployeeContainer employeeContainer = EmployeeContainer.Inst;
            List<Employee> employees = employeeContainer.GetEmployees();

            if (operation.Equals("PMLIST",StringComparison.CurrentCultureIgnoreCase))
            {
                foreach (ProjectManager p in employees.OfType<ProjectManager>())
                {
                    Console.WriteLine(p.FirstName + "," + p.LastName + "," + p.Age + ","
                        + p.Project);
                }
            }
            else if (operation.Equals("DEVLIST", StringComparison.CurrentCultureIgnoreCase))
            {
                foreach (Developer d in employees.OfType<Developer>())
                {
                    Console.WriteLine(d.FirstName + "," + d.LastName + "," + d.Age + ","
                        + d.Project + "," + d.IsStudent);
                }
            }
            else if (operation.Equals("STLIST", StringComparison.CurrentCultureIgnoreCase))
            {
                foreach (SoftwareTester s in employees.OfType<SoftwareTester>())
                {
                    Console.WriteLine(s.FirstName + "," + s.LastName + "," + s.Age + ","
                        + s.Project + "," + s.UsesAutomatedTests);
                }
            }
            else if (operation.Equals("DSNRLIST", StringComparison.CurrentCultureIgnoreCase))
            {
                foreach (Designer d in employees.OfType<Designer>())
                {
                    Console.WriteLine(d.FirstName + "," + d.LastName + "," + d.Age + ","
                        + d.Project + "," + d.CanDraw);
                }
            }
            else if (operation.Equals("CEOLIST", StringComparison.CurrentCultureIgnoreCase))
            {
                foreach (CEO c in employees.OfType<CEO>())
                {
                    Console.WriteLine(c.FirstName + "," + c.LastName + "," + c.Age + ","
                        + c.CeoYears);
                }
            }
        }

        public static void List()
        {
            EmployeeContainer employeeContainer = EmployeeContainer.Inst;
            List<Employee> employees = employeeContainer.GetEmployees();

            foreach (Employee emp in employees)
            {
                if (emp.GetType() == typeof(Developer))
                {
                    Console.WriteLine(Roles.Developer + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                }
                else if (emp.GetType() == typeof(ProjectManager))
                {
                    Console.WriteLine(Roles.ProjectManager + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                }
                else if (emp.GetType() == typeof(SoftwareTester))
                {
                    Console.WriteLine(Roles.SoftwareTester + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                }
                else if (emp.GetType() == typeof(Designer))
                {
                    Console.WriteLine(Roles.Designer + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
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
                    Console.WriteLine(Roles.Developer + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                else if(emp.GetType() == typeof(CEO))
                    Console.WriteLine(Roles.CEO + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                else if(emp.GetType() == typeof(SoftwareTester))
                    Console.WriteLine(Roles.SoftwareTester + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                else if (emp.GetType() == typeof(Designer))
                    Console.WriteLine(Roles.Designer + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
                else if (emp.GetType() == typeof(ProjectManager))
                    Console.WriteLine(Roles.ProjectManager + "," + emp.FirstName + "," + emp.LastName + "," + emp.Age);
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

            string ceoYears = String.Empty;
            string projectName = String.Empty;
            string checkBool = String.Empty;

            bool boolValue = false;

            EmployeeContainer container = EmployeeContainer.Inst;
            Validation validation = new Validation();

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
            if (role == "CEO")
            {
                do
                {
                    Console.Write("Enter years of being CEO:");
                    ceoYears = Console.ReadLine();
                    validation.CheckIntegerInput(ceoYears);
                } while (!validation.inputIsValid);
                Int32.TryParse(age, out int ageInt);
                Int32.TryParse(ceoYears, out int ceoYearsInt);
                Employee employee = new CEO(name, lastName, ageInt,ceoYearsInt);
                container.AddCEO(employee);
            }
            else if (role == "PM")
            {
                do
                {
                    Console.Write("Enter project name:");
                    projectName = Console.ReadLine();
                    validation.CheckInput(projectName);
                } while (!validation.inputIsValid);
                Int32.TryParse(age, out int ageInt);
                Employee employee = new ProjectManager(name, lastName, ageInt, projectName);
                container.AddEmployee(employee);
            }
            else if (role == "DEV")
            {
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
                Int32.TryParse(age, out int ageInt);
                Employee employee = new Developer(name, lastName, ageInt, projectName, boolValue);
                container.AddEmployee(employee);
            }
            else if(role=="DSNR")
            {
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
                Int32.TryParse(age, out int ageInt);
                Employee employee = new Designer(name, lastName, ageInt, projectName, boolValue);
                container.AddEmployee(employee);
            }
            else if (role == "ST")
            {
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
                Int32.TryParse(age, out int ageInt);
                Employee employee = new SoftwareTester(name, lastName, ageInt, projectName, boolValue);
                container.AddEmployee(employee);
            }
        }
    }
}

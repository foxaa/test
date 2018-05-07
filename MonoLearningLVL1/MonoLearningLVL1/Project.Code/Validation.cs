using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code
{
    public class Validation
    {
        public bool isHelpCommand;
        public bool isAddCommand;
        public bool isRemoveCommand;
        public bool isDisplayCommand;
        public bool isListCommand;
        public bool isRoleListCommand;

        public bool isCEORole;
        public bool isProjectManagerRole;
        public bool isDeveloperRole;
        public bool isDesignerRole;
        public bool isSoftwareTesterRole;

        public bool isYes;
        public bool isNo;

        public bool inputIsValid = false;

        public void CheckCommand(string command)
        {
            isHelpCommand = string.Equals(command, Commands.Help, StringComparison.CurrentCultureIgnoreCase);
            isAddCommand = string.Equals(command, Commands.Add, StringComparison.CurrentCultureIgnoreCase);
            isRemoveCommand = string.Equals(command, Commands.Remove, StringComparison.CurrentCultureIgnoreCase);
            isDisplayCommand = string.Equals(command, Commands.Display, StringComparison.CurrentCultureIgnoreCase);
            isListCommand = string.Equals(command, Commands.List, StringComparison.CurrentCultureIgnoreCase);
            isRoleListCommand = Commands.roleList.Contains(command, StringComparer.CurrentCultureIgnoreCase);

            if (!isHelpCommand && !isAddCommand && !isRemoveCommand && !isDisplayCommand && !isListCommand && !isRoleListCommand)
            {
                Console.WriteLine("Wrong command name");
                inputIsValid = false;
            }
            else if (String.IsNullOrEmpty(command))
            {
                Console.WriteLine("Please enter a command");
                inputIsValid = false;
            }
            else
                inputIsValid = true;
        }

        public void CheckRemoveCommand(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Enter name of employee to delete.");
                inputIsValid = false;
            }
            else
                inputIsValid = true;
        }

        public void CheckInput(string input)
        {
            bool isDigitPresent = input.Any(c => char.IsDigit(c));
            if(String.IsNullOrWhiteSpace(input) || isDigitPresent)
            {
                Console.WriteLine("Input incorrect, enter a word.");
                inputIsValid = false;
            }
            else
                inputIsValid = true;
        }

        public void CheckIntegerInput(string input)
        {
            bool isLetterPresent = input.Any(c => char.IsLetter(c));
            if (String.IsNullOrEmpty(input) || isLetterPresent)
            {
                Console.WriteLine("Input incorrect, enter a number.");
                inputIsValid = false;
            }
            else
                inputIsValid = true;
        }

        public void CheckRoleInput(string input)
        {
            isCEORole = string.Equals(input, Roles.CEO);
            isProjectManagerRole = string.Equals(input, Roles.ProjectManager);
            isDeveloperRole = string.Equals(input, Roles.Developer);
            isDesignerRole = string.Equals(input, Roles.Designer);
            isSoftwareTesterRole = string.Equals(input, Roles.SoftwareTester);

            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input incorrect");
                inputIsValid = false;
            }
            else if (!isCEORole && !isProjectManagerRole && !isDesignerRole && !isDeveloperRole && !isSoftwareTesterRole)
            {
                Console.WriteLine("Wrong role name");
                inputIsValid = false;
            }
            else            
                inputIsValid = true;
        }

        public bool CheckBoolInput(string input)
        {
            isYes = string.Equals(input, "YES", StringComparison.CurrentCultureIgnoreCase);
            isNo = string.Equals(input, "NO", StringComparison.CurrentCultureIgnoreCase);

            bool boolValue;

            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Enter YES/NO");
                inputIsValid = false;
                return boolValue = false;
            }
            else if (!isYes && !isNo)
            {
                Console.WriteLine("Enter YES/NO");
                inputIsValid = false;
                return boolValue = false;
            }
            else if (isYes)
            {
                inputIsValid = true;
                return boolValue = true;
            }
            else
            {
                inputIsValid = true;
                return boolValue = false;
            }
        }
    }
}

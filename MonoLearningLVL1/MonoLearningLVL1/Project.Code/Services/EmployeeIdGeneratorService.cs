using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Services
{
    public class EmployeeIdGeneratorService
    {
        int ID = 0;
        private static EmployeeIdGeneratorService Instance;
        private EmployeeIdGeneratorService() { }
        public static EmployeeIdGeneratorService Inst
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new EmployeeIdGeneratorService();

                }
                return Instance;
            }
        }
        public int IncId()
        {
            return ID++;
        }
    }
}

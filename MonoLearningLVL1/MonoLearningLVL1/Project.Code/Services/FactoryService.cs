using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Code.Services
{
    public class FactoryService
    {
        private readonly CeoService ceoService;
        private readonly DeveloperService devService;
        private readonly DesignerService dsnrService;
        private readonly SoftwareTesterService stService;
        private readonly ProjectManagerService pmService;

        public FactoryService()
        {
            ceoService = new CeoService();
            devService = new DeveloperService();
            dsnrService = new DesignerService();
            stService = new SoftwareTesterService();
            pmService = new ProjectManagerService();
        }

        public BaseCRUD GetServiceForAdd(string role)
        {
            switch(role)
            {
                case "CEO":
                    return ceoService;
                case "DEV":
                    return devService;
                case "DSNR":
                    return dsnrService;
                case "ST":
                    return stService;
                default:
                    return pmService;
            }
        }

        public void GetRoleList(string operation)
        {
            switch(true)
            {
                case bool a when operation.Equals("CEOLIST", StringComparison.CurrentCultureIgnoreCase):
                    ceoService.GetCeoList(operation);
                    break;
                case bool a when operation.Equals("DEVLIST", StringComparison.CurrentCultureIgnoreCase):
                    devService.GetDevList(operation);
                    break;
                case bool a when operation.Equals("DSNRLIST", StringComparison.CurrentCultureIgnoreCase):
                    dsnrService.GetDsnrList(operation);
                    break;
                case bool a when operation.Equals("STLIST", StringComparison.CurrentCultureIgnoreCase):
                    stService.GetStList(operation);
                    break;
                default:
                    pmService.GetPmList(operation);
                    break;
            }
        }
    }
}

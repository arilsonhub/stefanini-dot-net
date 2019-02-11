using Stefanini.Dtos;
using Stefanini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.serviceInterface
{
    interface ICustomerService
    {
        Customer[] getCustomers(CustomerFiltersDTO dto);
        City[] getCities(int regionId);
        Gender[] getGenders();
        Region[] getRegions();
        UserSys[] getSellers();
        Classification[] getClassifications();       
    }
}
using Stefanini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Repository
{
    interface CityRepository
    {
        City[] getCities(int regionId);
    }
}

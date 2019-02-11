using Stefanini.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.serviceInterface
{
    interface IAutenticationService
    {
       void Autenticate(AutenticationDTO autenticationDTO);
    }
}
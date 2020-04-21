using Microsoft.AspNetCore.Mvc;
using SoftDale.Models;
using SoftDale.Models.Response;
using SoftDale.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftDale.Services
{
    public interface IClienteService
    {
        MyResponse AddCliente(Cliente cliente);
        MyResponse DeleteCliente([FromBody]ClienteViewModel model);
        IEnumerable<ClienteViewModel> ListCliente();
        MyResponse Add([FromBody]ClienteViewModel model);
        MyResponse Edit([FromBody]ClienteViewModel model);
        Cliente GetCliente(int id);
    }
}

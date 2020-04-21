using Microsoft.AspNetCore.Mvc;
using SoftDale.Models.Response;
using SoftDale.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftDale.Services
{
    public interface IClienteXServicioService
    {
        IEnumerable<ClienteXServicioViewModel> ListClienteXServicio();
        MyResponse Add([FromBody]ClienteXServicioViewModel model);
    }
}

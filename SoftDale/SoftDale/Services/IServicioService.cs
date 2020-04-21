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
    public interface IServicioService
    {
        MyResponse AddServicio(Servicio servicio);

        IEnumerable<ServicioViewModel> ListServicios();

        MyResponse Add([FromBody]ServicioViewModel model);

    }
}

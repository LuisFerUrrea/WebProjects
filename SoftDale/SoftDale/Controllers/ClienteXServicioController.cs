using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftDale.Models.Response;
using SoftDale.Models.ViewModels;
using SoftDale.Services;

namespace SoftDale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteXServicioController : Controller
    {

        private readonly IClienteXServicioService _clienteXServicioService;
        public ClienteXServicioController(IClienteXServicioService clienteXServicioService)
        {
            _clienteXServicioService = clienteXServicioService;
        }

        [HttpGet("[action]")]
        public IEnumerable<ClienteXServicioViewModel> ListCliente()
        {
            return _clienteXServicioService.ListClienteXServicio();
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody]ClienteXServicioViewModel model)
        {
            return _clienteXServicioService.Add(model);
        }
    }
}
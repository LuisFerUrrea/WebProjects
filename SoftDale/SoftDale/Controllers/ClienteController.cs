using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftDale.Models;
using SoftDale.Models.Response;
using SoftDale.Models.ViewModels;
using SoftDale.Services;

namespace SoftDale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("[action]")]
        public IEnumerable<ClienteViewModel> ListCliente()
        {
            return _clienteService.ListCliente();
        }

        [HttpGet("[action]")]
        public Cliente GetCliente(int id)
        {
            return _clienteService.GetCliente(id);
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody]ClienteViewModel model)
        {
            return _clienteService.Add(model);
        }

        [HttpPost("[action]")]
        public MyResponse Edit([FromBody]ClienteViewModel model)
        {
            return _clienteService.Edit(model);
        }

        [HttpPost("[action]")]
        public MyResponse Delete([FromBody]ClienteViewModel model)
        {
            return _clienteService.DeleteCliente(model);
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
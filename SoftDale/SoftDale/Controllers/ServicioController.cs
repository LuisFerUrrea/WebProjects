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
    public class ServicioController : Controller
    {
        private readonly IServicioService _servicioService;
        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet("[action]")]
        public IEnumerable<ServicioViewModel> ListServicios()
        {
            return _servicioService.ListServicios();
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody]ServicioViewModel model)
        {
            return _servicioService.Add(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
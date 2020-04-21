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
    public class PaisController : Controller
    {
        private readonly IPaisService _paisService;
        public PaisController(IPaisService paisService)
        {
            _paisService = paisService;
        }

        [HttpGet("[action]")]
        public IEnumerable<PaisViewModel> ListPais()
        {
            return _paisService.ListPais();
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody]PaisViewModel model)
        {
            return _paisService.Add(model);
        }

        [HttpPost("[action]")]
        public MyResponse Delete([FromBody]PaisViewModel model)
        {
            return _paisService.DeletePais(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
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
    public interface IPaisService
    {
        MyResponse AddPais(Pais pais);
        MyResponse DeletePais([FromBody]PaisViewModel model);
        IEnumerable<PaisViewModel> ListPais();
        MyResponse Add([FromBody]PaisViewModel model);
    }
}

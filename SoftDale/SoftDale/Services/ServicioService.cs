using Microsoft.AspNetCore.Mvc;
using SoftDale.Context;
using SoftDale.Models;
using SoftDale.Models.Response;
using SoftDale.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftDale.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IApplicationDbContext _contextDB;
        private MyResponse _myResponse;

        public ServicioService(IApplicationDbContext contextDB)
        {
            _contextDB = contextDB;
        }

        public MyResponse AddServicio(Servicio servicio)
        {
            try
            {
                _contextDB.Servicios.Add(servicio);
                _contextDB.SaveChanges();
                _myResponse.Success = 1;
            }
            catch (Exception ex)
            {
                _myResponse.Success = 0;
                _myResponse.Message = ex.Message;
            }
            return _myResponse;
        }

        public MyResponse DeleteServicio([FromBody]ServicioViewModel model)
        {
            try
            {
                Servicio objServicio = _contextDB.Servicios.Find(model.Id);
                _contextDB.Servicios.Remove(objServicio);
                _contextDB.SaveChanges();
                _myResponse.Success = 1;
            }
            catch (Exception ex)
            {
                _myResponse.Success = 0;
                _myResponse.Message = ex.Message;
            }
            return _myResponse;
        }



        public IEnumerable<ServicioViewModel> ListServicios()
        {
            List<ServicioViewModel> lst = (from d in _contextDB.Servicios
                                           select new ServicioViewModel
                                           {
                                               Id = d.Id,
                                               Nombre = d.Nombre,
                                               ValorHora = d.ValorHora
                                           }).ToList();
            return lst;
        }


        public MyResponse Add([FromBody]ServicioViewModel model)
        {
            try
            {
                Servicio objServicio = new Servicio();
                objServicio.Nombre = model.Nombre;
                objServicio.ValorHora = model.ValorHora;
                _contextDB.Servicios.Add(objServicio);
                _contextDB.SaveChanges();
                _myResponse.Success = 1;
            }
            catch (Exception ex)
            {

                _myResponse.Success = 0;
                _myResponse.Message = ex.Message;
            }
            return _myResponse;
        }

    }
}

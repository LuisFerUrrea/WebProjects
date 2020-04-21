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
    public class PaisService : IPaisService
    {
        private readonly IApplicationDbContext _contextDB;
        private MyResponse _myResponse;

        public PaisService(IApplicationDbContext contextDB)
        {
            _contextDB = contextDB;
        }

        public MyResponse AddPais(Pais pais)
        {
            try
            {
                _contextDB.Pais.Add(pais);
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

        public MyResponse DeletePais([FromBody]PaisViewModel model)
        {
            try
            {
                Pais objPais = _contextDB.Pais.Find(model.Id);
                _contextDB.Pais.Remove(objPais);
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

        public IEnumerable<PaisViewModel> ListPais()
        {
            try
            {
                List<PaisViewModel> lst = (from d in _contextDB.Pais
                                           select new PaisViewModel
                                           {
                                               Id = d.Id,
                                               Nombre = d.Nombre
                                           }).ToList();
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public MyResponse Add([FromBody]PaisViewModel model)
        {
            try
            {
                Pais objPais = new Pais();
                objPais.Nombre = model.Nombre;
                _contextDB.Pais.Add(objPais);
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

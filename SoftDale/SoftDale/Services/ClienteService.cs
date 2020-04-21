using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
    public class ClienteService : IClienteService
    {
        private readonly IApplicationDbContext _contextDB;
        private readonly IMemoryCache _memoryCache;
        private MyResponse _myResponse = new MyResponse();

        public ClienteService(IApplicationDbContext contextDB, IMemoryCache memoryCache)
        {
            _contextDB = contextDB;
            _memoryCache = memoryCache;
        }

        public MyResponse AddCliente(Cliente cliente)
        {
            try
            {
                _contextDB.Clientes.Add(cliente);
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

        public MyResponse DeleteCliente([FromBody]ClienteViewModel model)
        {
            try
            {
                Cliente objCliente = _contextDB.Clientes.Find(model.Id);
                _contextDB.Clientes.Remove(objCliente);
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

        public IEnumerable<ClienteViewModel> ListCliente()
        {
            try
            {
                List<ClienteViewModel> lst = (from d in _contextDB.Clientes
                                              select new ClienteViewModel
                                              {
                                                  Id = d.Id,
                                                  Nombre = d.Nombre,
                                                  Correo = d.Correo
                                              }).ToList();
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Cliente GetCliente(int id)
        {
            try
            {
                Cliente objCliente = _contextDB.Clientes.Find(id);
                return objCliente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MyResponse Add([FromBody]ClienteViewModel model)
        {
            try
            {
                _myResponse.Success = 0;
                if (model.tipoAlmacenamiento == "bd")
                {
                    Cliente objCliente = new Cliente();
                    objCliente.Nombre = model.Nombre;
                    objCliente.Correo = model.Correo;
                    _contextDB.Clientes.Add(objCliente);
                    _contextDB.SaveChanges();
                    _myResponse.Success = 1;
                }
                else if (model.tipoAlmacenamiento == "cache")
                {
                    _memoryCache.Set("AddCliente", model);
                    _myResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                _myResponse.Message = ex.Message;
            }
            return _myResponse;
        }

        public MyResponse Edit([FromBody]ClienteViewModel model)
        {
            try
            {
                _myResponse.Success = 0;
                if (model.tipoAlmacenamiento == "bd")
                {
                    Cliente objCliente = new Cliente();
                    objCliente.Id = model.Id;
                    objCliente.Nombre = model.Nombre;
                    objCliente.Correo = model.Correo;
                    _contextDB.Clientes.Update(objCliente);
                    _contextDB.SaveChanges();
                    _myResponse.Success = 1;
                }
                else if (model.tipoAlmacenamiento == "cache")
                {
                    _memoryCache.Set("EditCliente", model);
                    _myResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                _myResponse.Message = ex.Message;
            }
            return _myResponse;
        }


    }
}


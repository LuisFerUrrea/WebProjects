using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftDale.Models.ViewModels
{
    public class ClienteXServicioViewModel : General
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int ServicioId { get; set; }

        public string NombreCliente { get; set; }

        public string Correo { get; set; }

        public string NombreServicio { get; set; }

        public Decimal ValorHora { get; set; }

        public int PaisId { get; set; }

        public string NombrePais { get; set; }

        public int ClienteServicioXPaisId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftDale.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Decimal ValorHora { get; set; }
        List<ClienteXServicio> ClienteXServicios { get; set; }
    }
}

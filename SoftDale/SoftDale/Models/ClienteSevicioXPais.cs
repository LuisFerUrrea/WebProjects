using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftDale.Models
{
    public class ClienteSevicioXPais
    {
        public int Id { get; set; }
        public int ClienteXServicioId { get; set; }
        public int PaisId { get; set; }
    }
}

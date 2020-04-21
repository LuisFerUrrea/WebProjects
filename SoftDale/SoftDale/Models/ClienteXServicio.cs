using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftDale.Models
{
    public class ClienteXServicio
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int ServicioId { get; set; }

        List<ClienteSevicioXPais> ClienteSevicioXPais { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftDale.Models.ViewModels
{
    public class ClienteViewModel : General
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }


    }
}

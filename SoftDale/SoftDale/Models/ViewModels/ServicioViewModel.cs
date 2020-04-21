using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftDale.Models.ViewModels
{
    public class ServicioViewModel : General
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Decimal ValorHora { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Entity.Entity
{
    public class Movimiento
    {
        public int idMovimiento { get; set; }
        public string nroCuenta { get; set; }   
        public DateTime fecha { get; set; }
        public string tipo { get; set; }
        public decimal importe { get; set; }
    }
}

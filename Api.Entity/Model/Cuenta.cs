using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Entity.Entity
{
    public class Cuenta
    {
        public string nroCuenta { get; set; }
        public string tipo { get; set; }
        public string moneda { get; set; }
        public string nombre { get; set; }
        public decimal saldo { get; set; }
        public object JsonConvert { get; set; }
    }
}

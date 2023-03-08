using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Entity.Request
{
    public class cuentaRequest
    {
    }
    public class nroCuentaRequest
    {
        public string nroCuenta { get; set; }
    }
    public class saldoCuentaRequest : nroCuentaRequest
    {
        public decimal saldo { get; set; }
    }
}

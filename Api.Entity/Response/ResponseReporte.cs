using Api.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Entity.Response
{
    public class ResponseReporte : Cuenta
    {
        public string pdfBase64 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Entity.Entity.Settings
{
    public class dataBaseEntity
    {
        public string name { get; set; }
        public List<conexion> connections { get; set; }
    }
    public class conexion
    {
        public string name { get; set; }
        public string server { get; set; }
        public string dataBase { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public int timeOut { get; set; }
    }
}

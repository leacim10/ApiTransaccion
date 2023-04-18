using Api.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Security
{
    public interface IManagerSecurity
    {
        bool User(string user, string password);
    }
    public class ManagerSecurity : IManagerSecurity
    {
        List<Usuario> users = new List<Usuario>()
        {
            new Usuario(){user = "mika", password = "123abc"},
            new Usuario(){user = "leacim", password = "123abc"}
        };
        public bool User(string user, string password) =>
            users.Where(d => d.user == user && d.password == password).Count() > 0;
    }
}
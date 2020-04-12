using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessLogic
{
    public class UsuarioLogic
    {
        public List<Usuario> Buscar(string nombre, string password)
        {
            using (var context = new FacturadorContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;

                var usuarios = context.Usuario.OrderBy(x => x.Username)
                                        .Where(x => x.Username.Contains(nombre) && x.Password.Contains(password))
                                        .Take(1)
                                        .ToList();

                return usuarios;
            }
        }

    }
}

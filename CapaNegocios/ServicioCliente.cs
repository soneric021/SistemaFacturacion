using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    class ServicioCliente : IServicioBase<Cliente>
    {
        public void Create(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> Get()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}

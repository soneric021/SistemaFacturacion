using CapaEntidades;
using System.Collections.Generic;
using System.Linq;
using CapaDatos;


namespace CapaNegocios
{
    public class ServicioCliente :  IServicioBase<Cliente>
    {
        private ClienteDatos clienteDatos = new ClienteDatos();

        public void Create(Cliente cliente)
        {
            clienteDatos.Create(cliente);
        }

      
        public void Delete(int id)
        {
            clienteDatos.Delete(id);
        }

        public List<Cliente> Get()
        {
            return clienteDatos.Get();
        }

        public Cliente GetById(int? id)
        {
            return clienteDatos.GetById(id);
        }

  
        public void Update(Cliente cliente)
        {
            clienteDatos.Update(cliente);
        }
    }
}

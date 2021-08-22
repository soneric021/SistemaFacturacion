using CapaEntidades;
using System.Collections.Generic;
using System.Linq;


namespace CapaNegocios
{
    public class ClienteDatos : Base, IDatosBase<Cliente>
    {
       

        public void Create(Cliente cliente)
        {
            _dbContext.clientes.Add(cliente);
            _dbContext.SaveChanges();
        }

      
        public void Delete(int id)
        {
            var clienteToDelete = _dbContext.clientes.Find(id);
            _dbContext.clientes.Remove(clienteToDelete);
            _dbContext.SaveChanges();
        }

        public List<Cliente> Get()
        {
           return _dbContext.clientes.ToList();
        }

      

        public Cliente GetById(int? id)
        {
            return _dbContext.clientes.FirstOrDefault(x => x.Id == id);
        }

  
        public void Update(Cliente cliente)
        {
            var clienteToUpdate = _dbContext.clientes.Find(cliente.Id);
            _dbContext.Entry(clienteToUpdate).CurrentValues.SetValues(cliente);
            _dbContext.SaveChanges();
        }
    }
}

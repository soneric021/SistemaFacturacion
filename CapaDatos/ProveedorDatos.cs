using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class ProveedorDatos : Base, IDatosBase<Proveedor>
    {
    

        public void Create(Proveedor proveedor)
        {
            _dbContext.proveedores.Add(proveedor);
            _dbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            var proveedorToDelete = _dbContext.proveedores.Find(id);
            _dbContext.proveedores.Remove(proveedorToDelete);
            _dbContext.SaveChanges();
        }

        public List<Proveedor> Get()
        {
            return _dbContext.proveedores.ToList();
        }

        public Proveedor GetById(int? id)
        {
            return _dbContext.proveedores.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Proveedor proveedor)
        {
            var proveedorToUpdate = _dbContext.proveedores.Find(proveedor.Id);
            _dbContext.Entry(proveedorToUpdate).CurrentValues.SetValues(proveedor);
            _dbContext.SaveChanges();
        }
    }
}

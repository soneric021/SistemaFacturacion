using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    class ServicioProveedor : IServicioBase<Proveedor>
    {
        private SistemaFacturacionDbContext _dbContext;
        public ServicioProveedor(SistemaFacturacionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Proveedor proveedor)
        {
            _dbContext.proveedores.Add(proveedor);
            _dbContext.SaveChanges();

        }

        public List<Proveedor> Get()
        {
            return _dbContext.proveedores.ToList();
        }

        public Proveedor GetById(int id)
        {
            return _dbContext.proveedores.SingleOrDefault(x => x.Id == id);
        }

        public void Update(int id)
        {
            var prov = _dbContext.proveedores.Find(id);
        }
    }
}

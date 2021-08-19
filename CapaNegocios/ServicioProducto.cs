using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    class ServicioProducto : IServicioBase<Producto>
    {
        private SistemaFacturacionDbContext _dbContext;
        public ServicioProducto(SistemaFacturacionDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Producto producto)
        {
            _dbContext.productos.Add(producto);
            _dbContext.SaveChanges();
        }

        public List<Producto> Get()
        {
            return _dbContext.productos.ToList();
        }

        public Producto GetById(int id)
        {
            return _dbContext.productos.FirstOrDefault(x => x.Id == id);
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}

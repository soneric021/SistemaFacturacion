using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class ServicioProducto : IServicioBase<Producto>
    {

        private ProductoDatos productoDatos = new ProductoDatos();
        public void Create(Producto producto)
        {
            productoDatos.Create(producto);
        }

        public void Delete(int id)
        {
            productoDatos.Delete(id);
        }

        public List<Producto> Get()
        {
            return productoDatos.Get();
        }
        
        public Producto GetById(int? id)
        {
            return productoDatos.GetById(id);
        }

        public void Update(Producto producto)
        {
            productoDatos.Update(producto);
        }
    }
}

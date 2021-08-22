using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class ServicioProveedor :  IServicioBase<Proveedor>
    {
        private ProveedorDatos proveedorDatos = new ProveedorDatos();

        public void Create(Proveedor proveedor)
        {
            proveedorDatos.Create(proveedor);

        }

        public void Delete(int id)
        {
            proveedorDatos.Delete(id);
        }

        public List<Proveedor> Get()
        {
            return proveedorDatos.Get();
        }

        public Proveedor GetById(int? id)
        {
            return proveedorDatos.GetById(id);
        }

        public void Update(Proveedor proveedor)
        {
            proveedorDatos.Update(proveedor);
        }
    }
}

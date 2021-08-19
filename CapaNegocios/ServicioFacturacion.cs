using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    class ServicioFacturacion : Base,IServicioBase<Facturacion>
    {
      
        public void Create(Facturacion facturacion)
        {
            _dbContext.facturaciones.Add(facturacion);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Facturacion> Get()
        {
            return _dbContext.facturaciones.ToList();
        }

        public Facturacion GetById(int? id)
        {
            return _dbContext.facturaciones.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Facturacion facturacion)
        {
            var facturacionToUpdate = _dbContext.facturaciones.Find(facturacion.Id);
            _dbContext.Entry(facturacionToUpdate).CurrentValues.SetValues(facturacion);
            _dbContext.SaveChanges();
        }
    }
}

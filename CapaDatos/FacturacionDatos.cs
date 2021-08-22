using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class FacturacionDatos : Base,IDatosBase<Facturacion>
    {
      
        public void Create(Facturacion facturacion)
        {
            _dbContext.facturaciones.Add(facturacion);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var facturacion = _dbContext.facturaciones.Find(id);
            _dbContext.facturaciones.Remove(facturacion);
        }

        public List<Facturacion> Get()
        {
            return _dbContext.facturaciones.Include(x => x.cliente).ToList();
        }
        public List<DetalleFactura> GetDetalleFacturasByFactura(int? id)
        {
            return _dbContext.detalleFacturas.Include(x => x.producto).Where(x => x.IdFacturacion == id).ToList();
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

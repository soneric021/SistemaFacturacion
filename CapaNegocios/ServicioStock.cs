using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class ServicioStock : IServicioBase<Stock>
    {
        private StockDatos stockDatos = new StockDatos();
        
        public void Create(Stock stock)
        {
            stockDatos.Create(stock);
        }

        public void Delete(int id)
        {
            stockDatos.Delete(id);
        }

        public List<Stock> Get()
        {
           return stockDatos.Get();
        }

        public Stock GetById(int? id)
        {
            return stockDatos.GetById(id);
        }

        public void Update(Stock stock)
        {
            stockDatos.Update(stock);
        }
    }
}

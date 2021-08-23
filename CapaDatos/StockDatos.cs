using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class StockDatos : Base, IDatosBase<Stock>
    {
    
        
        public void Create(Stock stock)
        {
            var stockToUpdate = _dbContext.stocks.FirstOrDefault(x => x.IdProductoStock == stock.IdProductoStock);
            if (stockToUpdate != null)
            {
                stockToUpdate.Cantidad += stock.Cantidad;
                stockToUpdate.IdProveedor = stock.IdProveedor;
                _dbContext.Entry(stockToUpdate).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            else
            {
                _dbContext.stocks.Add(stock);
                _dbContext.SaveChanges();
            }
          
        }

        public void Delete(int id)
        {
            //var proveedorToDelete = _dbContext.proveedores.Find(id);
            //_dbContext.proveedores.Remove(proveedorToDelete);
            //_dbContext.SaveChanges();
        }

        public List<Stock> Get()
        {
            return _dbContext.stocks.Include(x => x.producto).Include(x => x.proveedor).ToList();
        }

        public Stock GetById(int? id)
        {
            return _dbContext.stocks.FirstOrDefault(x => x.IdProductoStock == id);
        }

        public void Update(Stock stock)
        {
            var stockToUpdate = _dbContext.stocks.Find(stock.IdProductoStock);
            _dbContext.Entry(stockToUpdate).CurrentValues.SetValues(stock);
            _dbContext.SaveChanges();
        }
        public void UpdateStockByIdProduct(int id, int cantidad)
        {
            var stockToUpdate = _dbContext.stocks.FirstOrDefault(x =>x.IdProductoStock == id);
            stockToUpdate.Cantidad -= cantidad;
            _dbContext.Entry(stockToUpdate).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}

using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    class ServicioStock : Base, IServicioBase<Stock>
    {
    
        
        public void Create(Stock stock)
        {
            _dbContext.stocks.Add(stock);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Stock> Get()
        {
           return _dbContext.stocks.ToList();
        }

        public Stock GetById(int? id)
        {
            return _dbContext.stocks.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Stock stock)
        {
            var stockToUpdate = _dbContext.stocks.Find(stock.Id);
            _dbContext.Entry(stockToUpdate).CurrentValues.SetValues(stock);
            _dbContext.SaveChanges();
        }
    }
}

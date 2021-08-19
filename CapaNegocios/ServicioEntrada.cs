using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    class ServicioEntrada : Base, IServicioBase<Entrada>
    {
       
        public void Create(Entrada entrada)
        {
            _dbContext.entradas.Add(entrada);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entrada> Get()
        {
            return _dbContext.entradas.ToList();
        }

        public Entrada GetById(int? id)
        {
            return _dbContext.entradas.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Entrada entrada)
        {
            var entradaToUpdate = _dbContext.entradas.Find(entrada.Id);
            _dbContext.Entry(entradaToUpdate).CurrentValues.SetValues(entrada);
            _dbContext.SaveChanges();
        }
    }
}

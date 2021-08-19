﻿using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    class ServicioProducto : Base, IServicioBase<Producto>
    {
        
      
        public void Create(Producto producto)
        {
            _dbContext.productos.Add(producto);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> Get()
        {
            return _dbContext.productos.ToList();
        }

        public Producto GetById(int? id)
        {
            return _dbContext.productos.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Producto producto)
        {
            var productoToUpdate = _dbContext.productos.Find(producto.Id);
            _dbContext.Entry(productoToUpdate).CurrentValues.SetValues(producto);
            _dbContext.SaveChanges();
        }
    }
}

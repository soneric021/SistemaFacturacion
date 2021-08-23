using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public abstract class Base
    {
        
        protected SistemaFacturacionDbContext _dbContext;
        protected Base()
        {
            _dbContext = new SistemaFacturacionDbContext();
        }
       
    }
}

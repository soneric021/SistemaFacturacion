using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    interface IDatosBase<T>
    {
    
        List<T> Get();
        T GetById(int? id);
        void Create(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}

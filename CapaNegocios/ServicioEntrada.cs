using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class ServicioEntrada : IServicioBase<Entrada>
    {
        private EntradaDatos entradaDatos = new EntradaDatos();
       
        public void Create(Entrada entrada)
        {
            entradaDatos.Create(entrada);
        }

        public void Delete(int id)
        {
            entradaDatos.Delete(id);
        }

        public List<Entrada> Get()
        {
            return entradaDatos.Get();
        }

        public Entrada GetById(int? id)
        {
            return entradaDatos.GetById(id);
        }

        public void Update(Entrada entrada)
        {
            entradaDatos.Update(entrada);
        }
    }
}

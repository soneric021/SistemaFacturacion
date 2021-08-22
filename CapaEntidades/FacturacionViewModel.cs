using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class FacturacionViewModel
    {
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public double Total { get; set; }
        public List<ProductoViewModel> productos { get; set; }
     }
}

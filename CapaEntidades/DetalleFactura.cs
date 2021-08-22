using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
   public class DetalleFactura
    {
        public int Id { get; set; }
        public int IdFacturacion { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        // public int Cantidad { get; set; }

        [ForeignKey("IdProducto")]
        public Producto producto { get; set; }

        [ForeignKey("IdFacturacion")]
        public Facturacion facturacion { get; set; }
    }
}

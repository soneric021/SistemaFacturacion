using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CapaEntidades
{
    class Facturacion
    {
        [Key]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        [Required]
        public double Total { get; set; }
        public int IdProducto { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        [ForeignKey("IdProducto")]
        public List<Producto> productos { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente cliente { get; set; }

       

    }
}

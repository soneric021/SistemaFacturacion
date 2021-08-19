using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CapaEntidades
{
    public class Facturacion
    {
        [Key]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        [Required]
        public double Total { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public ICollection<Producto> productos { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente cliente { get; set; }

       

    }
}

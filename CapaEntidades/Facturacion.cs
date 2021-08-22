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
        public double Itbis { get; set; }
        public double Descuento { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public ICollection<DetalleFactura> detalleFacturas { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente cliente { get; set; }

       

    }
}

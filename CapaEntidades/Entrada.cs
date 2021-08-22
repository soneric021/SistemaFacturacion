using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CapaEntidades
{
    public class Entrada
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Movimiento { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public int IdProveedor { get; set; }
        public int IdProducto { get; set; }

        [ForeignKey("IdProveedor")]
        public Proveedor proveedor { get; set; }
        [ForeignKey("IdProducto")]
        public Producto producto { get; set; }
    }
}

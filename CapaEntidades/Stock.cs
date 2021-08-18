using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CapaEntidades
{
    class Stock
    {
        public int IdProveedor { get; set; }
        public int IdProducto { get; set; }
        [Required]
        public int Cantidad { get; set; }


        [ForeignKey("idProveedor")]
        public Proveedor proveedor { get; set; }
        [ForeignKey("idProducto")]
        public Producto producto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CapaEntidades
{
    public class Stock
    {
        [Key,ForeignKey("producto")]
        public int IdProductoStock { get; set; }

        public int IdProveedor { get; set; }
        [Required]
        public int Cantidad { get; set; }
        


        [ForeignKey("IdProveedor")]
        public Proveedor proveedor { get; set; }
      
        public virtual Producto producto { get; set; }
    }
}

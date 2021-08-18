using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapaEntidades
{
    class Entradas
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Movimiento { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapaEntidades
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(13, ErrorMessage ="El campo {0} no puede exceder los {1} caracteres")]
        public string Cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres")]
        public string Telefono { get; set; }
        [Required]
        public string Email { get; set; }
    }
}

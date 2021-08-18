using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapaEntidades
{
    class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(13, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres")]
        public int Cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede exceder los {1} caracteres ")]
        public int Telefono { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Categoria { get; set; } // 0 premium - 1 regular

    }
}

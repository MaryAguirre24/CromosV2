using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BD.Data.Entity
{
    public class Proveedor : EntityBase
    {
        [Required(ErrorMessage = "El nombre del proveedor es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder los {1} caracteres")]
        public string Nombre { get; set; }
        public int? Telefono { get; set; }
        [MaxLength(60, ErrorMessage = "El email no puede exceder los {1} caracteres")]
        public string? Email { get; set; }
        [MaxLength(120, ErrorMessage = "La dirección no puede exceder los {1} caracteres")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "El coeficiente asignado al proveedor es obligatorio")]
        public decimal Coeficiente { get; set; }
        [Required(ErrorMessage = "El estado del proveedor es obligatorio")]
        public bool Estado { get; set; } = true;
        public List<IngresoProveedor?> IngresosProveedor { get; set; }

    }
}

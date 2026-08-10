using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    public class Producto : EntityBase
    {
        public int ProveedorId { get; set; }
        [ForeignKey(nameof(ProveedorId))]
        public Proveedor Proveedor { get; set; }
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre del producto no puede exceder los {1} caracteres")]
        public string Nombre { get; set; }
        [MaxLength(200, ErrorMessage = "La descripción no puede exceder los {1} caracteres")]
        public string? Descripcion { get; set; } = null;
        [Required(ErrorMessage = "El precio de venta es obligatorio")]
        public int PrecioVenta { get; set; }
        [Required(ErrorMessage = "El estado del producto es obligatorio")]
        public int Stock { get; set; } = 0;
        [Required(ErrorMessage = "El estado del producto es obligatorio")]
        public bool Estado { get; set; } = true;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    public class Producto : EntityBase
    {
        [MaxLength(20, ErrorMessage = "El código no puede exceder los {1} caracteres")]
        public string Codigo { get; set; } // Ejemplo: "R001"
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre del producto no puede exceder los {1} caracteres")]
        public string Nombre { get; set; }
        [MaxLength(200, ErrorMessage = "La descripción no puede exceder los {1} caracteres")]
        public string? Descripcion { get; set; } = null;
        [Required(ErrorMessage = "El precio de venta es obligatorio")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioVenta { get; set; }
        [Required(ErrorMessage = "El stock del producto es obligatorio")]
        public int Stock { get; set; } = 0;
        [Required(ErrorMessage = "El estado del producto es obligatorio")]
        public bool Estado { get; set; } = true;

        public int ProveedorId { get; set; }
        [ForeignKey(nameof(ProveedorId))]
        public Proveedor Proveedor { get; set; }
        public int CategoriaId { get; set; }
        [ForeignKey(nameof(CategoriaId))]
        public Categoria Categoria { get; set; }
    }
}

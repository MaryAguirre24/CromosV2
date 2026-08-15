using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BD.Data.Entity
{
    public class Oferta : EntityBase
    {
        [Required(ErrorMessage = "El nombre de la oferta es obligatorio")]
        [MaxLength(200, ErrorMessage = "El nombre no puede exceder los {1} caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La fecha de inicio de la oferta es obligatoria")]
        public decimal PorcentajeDescuento { get; set; } // Ej: 15.00 (%)
        public DateTime FechaInicio { get; set; } = DateTime.UtcNow;
        public DateTime? FechaFin { get; set; }
        [Required(ErrorMessage = "El precio de la oferta es obligatorio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "El estado de la oferta es obligatorio")]
        public bool Estado { get; set; }
        public List<OfertaProducto?> OfertasProductos { get; set; }

    }
}

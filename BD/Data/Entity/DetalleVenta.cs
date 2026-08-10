using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    public class DetalleVenta : EntityBase
    {
        [Required(ErrorMessage = "El ID de la venta es obligatorio")]
        public int VentaId { get; set; }
        [ForeignKey(nameof(VentaId))]
        public Venta Venta { get; set; }
        [Required(ErrorMessage = "El ID del producto es obligatorio")]
        public int ProductoId { get; set; }
        [ForeignKey(nameof(ProductoId))]
        public Producto Producto { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; } = 0;
        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        public int PrecioUnitario { get; set; } = 0;

    }
}

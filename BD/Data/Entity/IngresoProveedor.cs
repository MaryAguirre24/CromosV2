using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    public class IngresoProveedor : EntityBase
    {
        [Required(ErrorMessage = "El ID del proveedor es obligatorio")]
        public int ProveedorId { get; set; }
        [ForeignKey(nameof(ProveedorId))]
        public Proveedor Proveedor { get; set; }
        [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
        public DateTime FechaIngreso { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "El total es obligatorio")]
        public decimal Total { get; set; } = 0;
        public List<DetalleIngresoProveedor?> DetallesIngresoProveedor { get; set; }

    }
}

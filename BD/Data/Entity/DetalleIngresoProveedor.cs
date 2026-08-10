using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    [Index(nameof(IngresoProveedorId), nameof(ProductoId), Name = "DetalleIngresoProveedor_IngresoProveedorId_ProductoId_UQ", IsUnique = true)]
    public class DetalleIngresoProveedor : EntityBase
    {
        [Required(ErrorMessage = "El ID del producto es obligatorio")]
        public int ProductoId { get; set; }
        [ForeignKey(nameof(ProductoId))]
        public Producto Producto { get; set; }
        [Required(ErrorMessage = "El ID del ingreso del proveedor es obligatorio")]
        public int IngresoProveedorId { get; set; }
        [ForeignKey(nameof(IngresoProveedorId))]
        public IngresoProveedor IngresoProveedor { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El precio de compra es obligatorio")]
        public decimal PrecioCompra { get; set; }
        [Required(ErrorMessage = "El Estado es obligatorio")]
        public bool Estado { get; set; } = true;

    }
}

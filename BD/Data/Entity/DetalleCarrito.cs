using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    public class DetalleCarrito : EntityBase
    {
        [Required(ErrorMessage = "El ID del carrito es obligatorio")]
        public int CarritoId { get; set; }
        [ForeignKey(nameof(CarritoId))]
        public Carrito Carrito { get; set; }
        [Required(ErrorMessage = "El ID del producto es obligatorio")]
        public int ProductoId { get; set; }
        [ForeignKey(nameof(ProductoId))]
        public Producto Producto { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        public int PrecioUnitario { get; set; }

    }
}

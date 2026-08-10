using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    public class OfertaProducto : EntityBase
    {
        [Required(ErrorMessage = "El ID de la oferta a la que pertenece es obligatorio")]
        public int OfertaId { get; set; }
        [ForeignKey(nameof(OfertaId))]
        public Oferta Oferta { get; set; }
        [Required(ErrorMessage = "El ID del producto es obligatorio")]
        public int ProductoId { get; set; }
        [ForeignKey(nameof(ProductoId))]
        public Producto Producto { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; }

    }
}

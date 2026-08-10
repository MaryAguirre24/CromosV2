using Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    public class LogEstadoCarrito : EntityBase
    {
        public int CarritoId { get; set; }
        [ForeignKey(nameof(CarritoId))]
        public Carrito Carrito { get; set; }
        [Required(ErrorMessage = "El estado del carrito es obligatorio")]
        public EstadoCarrito EstadoCarrito { get; set; }
        [Required(ErrorMessage = "La fecha del cambio de Estado del carrito es obligatorio")]
        public DateTime Fecha { get; set; }

    }
}

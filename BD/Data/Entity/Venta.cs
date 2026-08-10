using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    public class Venta : EntityBase
    {
        [Required(ErrorMessage = "El ID del cliente es obligatorio")]
        public int ClienteId { get; set; }
        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }
        public int? CarritoId { get; set; }
        [ForeignKey(nameof(CarritoId))]
        public Carrito? Carrito { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El valor total es obligatorio")]
        public decimal Total { get; set; }
        [Required(ErrorMessage = "El monto adeudado es obligatorio")]
        public decimal MontoAdeudado { get; set; }
        public List<DetalleVenta?> DetallesVenta
        {
            get; set;
        }   
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    public class Cobro : EntityBase
    {
        [Required(ErrorMessage = "Declarar el cliente del cual proviene el pago es obligatorio")]
        public int ClienteId { get; set; }
        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }
        [Required(ErrorMessage = "La fecha del pago es obligatoria")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El monto total del pago es obligatorio")]
        public decimal MontoTotal { get; set; } = 0;
        [MaxLength(200, ErrorMessage = "Las observaciones no pueden exceder los {1} caracteres")]
        public string? Observaciones { get; set; }
        public List<CobroMetodoPago> CobrosMetodoPago { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    public class MovCuentaCorriente : EntityBase
    {
        [Required(ErrorMessage = "El Id del cliente es obligatorio")]
        public int ClienteId { get; set; }
        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }
        public int? VentaId { get; set; }
        [ForeignKey(nameof(VentaId))]
        public Venta? Venta { get; set; }
        public int? CobroId { get; set; }
        [ForeignKey(nameof(CobroId))]
        public Cobro? Cobro { get; set; }
        public int TipoCobroId { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio")]
        public decimal Monto { get; set; }
        [MaxLength(256, ErrorMessage = "Las observaciones no pueden exceder los {1} caracteres")]
        public string? Observaciones { get; set; } = string.Empty;

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    public class CobroMetodoPago : EntityBase
    {
        [Required(ErrorMessage = "Declarar el cobro al que corresponde el método de pago es obligatorio")]
        public int CobroId { get; set; }
        [ForeignKey(nameof(CobroId))]
        public Cobro Cobro { get; set; }
        [Required(ErrorMessage = "Declarar el tipo de cobro es obligatorio")]
        public int TipoCobroId { get; set; }
        [ForeignKey(nameof(TipoCobroId))]
        public TipoCobro TipoCobro { get; set; }
        [Required(ErrorMessage = "El monto del pago es obligatorio")]
        public decimal Monto { get; set; }

    }
}

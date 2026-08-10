using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BD.Data.Entity
{
    public class TipoCobro : EntityBase
    {
        [Required(ErrorMessage = "El nombre del tipo de pago es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre del tipo de pago no puede exceder los {1} caracteres")]
        public string Nombre { get; set; }
        public List<CobroMetodoPago?> CobrosMetodoPago { get; set; }

    }
}

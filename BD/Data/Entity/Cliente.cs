using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    [Index(nameof(PersonaId), Name = "Cliente_PersonaId_UQ", IsUnique = true)]
    public class Cliente : EntityBase
    {
        [Required(ErrorMessage = "Vincular la persona asociada es obligatorio")]
        public int PersonaId { get; set; }
        [ForeignKey(nameof(PersonaId))]
        public Persona Persona { get; set; }
        [Required(ErrorMessage = "La fecha de registro es obligatoria")]
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "El estado del cliente es obligatorio")]
        public bool Estado { get; set; }
        public List<Cobro?> Cobros { get; set; }
        public List<Venta?> Ventas { get; set; }
        public List<MovCuentaCorriente?> MovimientosCuentaCorriente { get; set; }

    }
}

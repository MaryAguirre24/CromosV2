using Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    public class Carrito : EntityBase
    {
        [Required(ErrorMessage = "El ID del usuario es obligatorio")]
        public int UsuarioId { get; set; }
        [ForeignKey(nameof(UsuarioId))]
        public Usuario Usuario { get; set; }
        [Required(ErrorMessage = "La fecha de creación del carrito es obligatoria")]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "La fecha de última actualización del carrito es obligatoria")]
        public DateTime FechaUltimaActualizacion { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "El estado del carrito es obligatorio")]
        public EstadoCarrito Estado { get; set; }

        public List<DetalleCarrito?> DetallesCarrito { get; set; }
        public List<LogEstadoCarrito> LogEstadosCarrito { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    [Index(nameof(Email), Name = "Usuario_Email_UQ", IsUnique = true)]
    [Index(nameof(PersonaId), Name = "Usuario_PersonaId_UQ", IsUnique = true)]
    public class Usuario : EntityBase
    {
        public int RolId { get; set; }
        [ForeignKey(nameof(RolId))]
        public Rol Rol { get; set; }
        public int PersonaId { get; set; }
        [ForeignKey(nameof(PersonaId))]
        public Persona Persona { get; set; }
        public int? ClienteId { get; set; }
        [ForeignKey(nameof(ClienteId))]
        public Cliente? Cliente { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Contrasena { get; set; }
        [Required(ErrorMessage = "El estado del usuario es obligatorio")]
        public bool Estado { get; set; }

    }
}

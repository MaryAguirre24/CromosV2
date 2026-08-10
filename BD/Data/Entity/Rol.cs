using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BD.Data.Entity
{
    [Index(nameof(Nombre), Name = "Rol_Nombre_UQ", IsUnique = true)]
    public class Rol : EntityBase
    {
        [Required(ErrorMessage = "El nombre del rol es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre del rol no puede exceder los {1} caracteres")]
        public string Nombre { get; set; }
        [MaxLength(200, ErrorMessage = "La descripción no puede exceder los {1} caracteres")]
        public string? Descripcion { get; set; }
        public List<Usuario?> Usuarios { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class VerPersonaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } 
        public string Apellido { get; set; } 
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}

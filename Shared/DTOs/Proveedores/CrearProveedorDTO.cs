using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs.Proveedores
{
    public class CrearProveedorDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public decimal Coeficiente { get; set; }
        public bool Estado { get; set; } = true;
    }
}

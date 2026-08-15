using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs.Productos
{
    public class CrearProductoDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; } = null;
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; } = 0;
        public bool Estado { get; set; } = true;
        public int CategoriaId { get; set; }
        public int ProveedorId { get; set; }
    }
}

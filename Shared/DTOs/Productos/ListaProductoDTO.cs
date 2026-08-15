using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs.Productos
{
    public class ListaProductoDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; } = null;
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; } = 0;
        public string CategoriaNombre { get; set; }
    }
}

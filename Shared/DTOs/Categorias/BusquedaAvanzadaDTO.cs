using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs.Categorias
{
    public class BusquedaAvanzadaDTO
    {
        public string? Nombre { get; set; }
        public int? CategoriaId { get; set; }
        public int? StockMin { get; set; }
        public int? StockMax { get; set; }
        public decimal? PrecioMin { get; set; }
        public decimal? PrecioMax { get; set; }
    }
}

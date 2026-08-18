using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs.Categorias
{
    public class ActualizarCategoriaDTO
    {
        public int Id { get; set; }
        public int? CategoriaPadreId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; } = true;
    }
}

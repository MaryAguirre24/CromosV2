using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs.Categorias
{
    public class CrearCategoriaDTO
    {
        public int? CategoriaPadreId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; } = true;

    }
}

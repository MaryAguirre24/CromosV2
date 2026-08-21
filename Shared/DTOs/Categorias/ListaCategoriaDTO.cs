using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs.Categorias
{
    public class ListaCategoriaDTO
    {
        public int Id { get; set; }
        public int? CategoriaPadreId { get; set; }
        public string ?Nombre { get; set; }
        public string ?Descripcion { get; set; }
        public bool Estado { get; set; } = true;

        public List<ListaCategoriaDTO> SubCategorias { get; set; } = new ();
    }
}

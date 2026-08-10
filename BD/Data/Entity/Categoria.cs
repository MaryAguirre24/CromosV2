using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    public class Categoria : EntityBase
    {
        public int? CategoriaPadreId { get; set; }
        [ForeignKey(nameof(CategoriaPadreId))]
        public Categoria? CategoriaPadre { get; set; }
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [MaxLength(60, ErrorMessage = "El nombre no puede exceder los {1} caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripción de la categoría es obligatoria")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "El estado de la categoría es obligatorio")]
        public bool Estado { get; set; } = true;
        public List<Categoria> SubCategorias { get; set; }

    }
}

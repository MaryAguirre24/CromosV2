using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD.Data.Entity
{
    [Index(nameof(CategoriaId), nameof(ProductoId), Name = "ProductoCategoria_CategoriaId_ProductoId_UQ", IsUnique = true)]
    public class ProductoCategoria : EntityBase
    {
        [Required(ErrorMessage = "El ID de la categoría es obligatorio")]
        public int CategoriaId { get; set; }
        [ForeignKey(nameof(CategoriaId))]
        public Categoria Categoria { get; set; }
        [Required(ErrorMessage = "El ID del producto es obligatorio")]
        public int ProductoId { get; set; }
        [ForeignKey(nameof(ProductoId))]
        public Producto Producto { get; set; }

    }
}

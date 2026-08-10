using BD.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BD.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cobro> Cobros { get; set; }
        public DbSet<CobroMetodoPago> CobrosMetodoPago { get; set; }
        public DbSet<DetalleCarrito> DetallesCarrito { get; set; }
        public DbSet<DetalleIngresoProveedor> DetallesIngresoProveedor { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }
        public DbSet<IngresoProveedor> IngresosProveedor { get; set; }
        public DbSet<LogEstadoCarrito> LogsEstadoCarrito { get; set; }
        public DbSet<MovCuentaCorriente> MovimientosCuentaCorriente { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<OfertaProducto> OfertasProductos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoCategoria> ProductoCategorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TipoCobro> TiposCobro { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
            // "CategoriaPadreId" acepta nulo o distinto de CategoriaId.
            // modelBuilder.Entity<Categoria>(b => { b.HasCheckConstraint("CK_Categoria_NoSelfParent", "CategoriaPadreId IS NULL OR CategoriaPadreId <> Id"); });

            base.OnModelCreating(modelBuilder);
        }
    }
}

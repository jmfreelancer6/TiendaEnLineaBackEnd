using Domain.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class TiendaEnLineaContext : DbContext
    {
        public TiendaEnLineaContext(DbContextOptions<TiendaEnLineaContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           // builder.Entity<Tbl_Productos>()
           // .HasMany<Tbl_Productos_Colores>(s => s.ProductosColores)
           // .WithOne(a=> a.)
            

           //builder.Entity<Tbl_Productos_Colores>()
           //.HasOne<Tbl_Colores>(s => s.Colores);
        }
        public DbSet<Tbl_Productos> Tbl_Productos { get; set; }
        public DbSet<Tbl_Productos_Colores> Tbl_Productos_Colores { get; set; }
        public DbSet<Tbl_Colores> Tbl_Colores { get; set; }

    }
}

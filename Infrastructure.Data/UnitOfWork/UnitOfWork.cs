using Domain.Core.Contracts;
using Domain.Core.Entity;
using Infrastructure.Data.Context;
using Infrastructure.Data.Persistent;

namespace Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TiendaEnLineaContext _context;
        public UnitOfWork(TiendaEnLineaContext context)
        {
            _context = context;
        }

        public IPagination<Tbl_Productos> ProductoRepository => new RepositoryProductos(_context);

        public IRepository<Tbl_Productos_Colores> ProductoColoresRepository => new RespositoryProductosColores(_context);

        public IRepository<Tbl_Colores> ColoresRepository => new RepositoryColores(_context);

        public IGetByExpression<Tbl_Productos_Colores> ProductoColoresByExpressioinRepository => new RespositoryProductosColores(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

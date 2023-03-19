using Domain.Core.Contracts;
using Domain.Core.Entity;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data.Persistent
{
    public class RepositoryProductos : RepositoryBase<Tbl_Productos>, IPagination<Tbl_Productos>
    {
        public RepositoryProductos(TiendaEnLineaContext context) : base(context) { }

        public async Task<IEnumerable<Tbl_Productos>> GetObjectByPagination(int currentPage, int pageSize) 
        {
            return await _context.Tbl_Productos.Include(a => a.ProductosColores).ThenInclude(b => b.Colores).Skip((currentPage - 1) * pageSize).Take(pageSize).ToArrayAsync();
        }

        public async Task<IEnumerable<Tbl_Productos>> GetObjectByPaginationBySearch(Expression<Func<Tbl_Productos, bool>> filter, int currentPage, int pageSize)
        {
            return await _context.Tbl_Productos.Include(a => a.ProductosColores).ThenInclude(b => b.Colores).Where(filter).Skip((currentPage - 1) * pageSize).Take(pageSize).ToArrayAsync();
        }

        public async Task<int> GetObjectTotalRecords()
        {
            return await _context.Tbl_Productos.CountAsync();
        }

        public async Task<int> GetObjectTotalRecordsBySearch(Expression<Func<Tbl_Productos, bool>> filter)
        {
            return await _context.Tbl_Productos.Where(filter).CountAsync();
        }
    }
}

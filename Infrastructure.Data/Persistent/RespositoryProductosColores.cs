using Domain.Core.Contracts;
using Domain.Core.Entity;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data.Persistent
{
    public class RespositoryProductosColores : RepositoryBase<Tbl_Productos_Colores>, IGetByExpression<Tbl_Productos_Colores>
    {
        public RespositoryProductosColores(TiendaEnLineaContext context) : base(context) { }

        public async Task<Tbl_Productos_Colores?> GetOneViewByFuncAsync(Expression<Func<Tbl_Productos_Colores, bool>> filter)
        {
            return await _context.Tbl_Productos_Colores.Where(filter).FirstOrDefaultAsync();
        }
    }
}

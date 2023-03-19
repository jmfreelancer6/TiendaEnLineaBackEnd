using Domain.Core.Entity;

namespace Domain.Core.Contracts
{
    public interface IUnitOfWork
    {
        public IPagination<Tbl_Productos> ProductoRepository { get; }
        public IRepository<Tbl_Productos_Colores> ProductoColoresRepository { get; }
        public IRepository<Tbl_Colores> ColoresRepository { get; }
        public IGetByExpression<Tbl_Productos_Colores> ProductoColoresByExpressioinRepository { get; }

    }
}

using Domain.Core.Entity;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repository;

namespace Infrastructure.Data.Persistent
{
    public  class RepositoryColores : RepositoryBase<Tbl_Colores>
    {
        public RepositoryColores(TiendaEnLineaContext context) : base(context) { }
    }
}

using System.Linq.Expressions;

namespace Domain.Core.Contracts
{
    public interface IPagination<T> : IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetObjectByPagination(int currentPage, int pageSize);
        Task<IEnumerable<T>> GetObjectByPaginationBySearch(Expression<Func<T, bool>> filter, int currentPage, int pageSize);
        Task<int> GetObjectTotalRecords();
        Task<int> GetObjectTotalRecordsBySearch(Expression<Func<T, bool>> filter);
    }
}

using System.Linq.Expressions;

namespace Domain.Core.Contracts
{
    public interface IGetByExpression<T> where T : class
    {
        Task<T?> GetOneViewByFuncAsync(Expression<Func<T, bool>> filter);
    }
}

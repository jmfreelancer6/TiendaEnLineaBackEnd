using System.Linq.Expressions;

namespace Domain.Core.Contracts
{
    public interface IGetView<T> where T : class
    {
        Task<IEnumerable<T>> GetViewAllAsync();
    }
}

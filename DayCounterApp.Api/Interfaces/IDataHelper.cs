using System.Collections.Generic;
using System.Threading.Tasks;

namespace DayCounterApp.Api.Interfaces
{
    public interface IDataHelper<T> where T : class
    {
        Task<T> Add(T t);

        Task<IEnumerable<T>> Get();

        Task<T> Get(int id);

        Task<T> Update();

        Task Delete();
    }
}

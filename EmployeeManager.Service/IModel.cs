using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManager.Service
{
    public interface IModel<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
    }
}

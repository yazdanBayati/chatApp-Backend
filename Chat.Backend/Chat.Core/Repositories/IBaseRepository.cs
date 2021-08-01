using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chat.Core.Domains
{
    public interface IBaseRepository<T>
    {
        int Add(T entity);

        Task<int> AddAsync(T entity);

        int Delete(T entity);

        Task<int> DeleteAsync(int id);

        T Get(int id);

        Task<T> GetAsync(int id);

        IQueryable<T> GetAll();

        void Detach(T entity);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IDataReponsitory<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        bool Delete(T entity);
        bool DeleteById(int Id);
        bool IsExists(T entity);
    }
}

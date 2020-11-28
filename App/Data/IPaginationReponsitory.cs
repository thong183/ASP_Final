using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IPaginationReponsitory<T> : IDataReponsitory<T> where T: class
    {
        Task<IEnumerable<T>> GetAll(int page);
        Task<int> CountAllPage();
        void UpdatePageCount(int page);
    }
}

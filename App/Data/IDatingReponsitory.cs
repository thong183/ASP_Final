using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Data
{
    public interface IDatingReponsitory<T>: IDataReponsitory<T> where T: class
    {
        Task<IEnumerable<T>> GetByDate(DateTime from, DateTime to);
    }
}

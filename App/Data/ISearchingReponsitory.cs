using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Data
{
    interface ISearchingReponsitory<T>: IDataReponsitory<T> where T: class
    {
        Task<IEnumerable<T>> Search(string key);
    }
}

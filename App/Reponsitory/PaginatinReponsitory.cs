using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace App.Reponsitory
{
    public class PaginatinReponsitory<T> : DataReponsitory<T>, IPaginationReponsitory<T> where T : class
    {
        protected int pageCount;

        public PaginatinReponsitory(IOptionsMonitor<PaginOption> option, DataContext context):base(context)
        {
            pageCount = option.CurrentValue.pageCount;
        }
        public async Task<IEnumerable<T>> GetAll(int page)
        {
            // page = 1 => 0 => 9
            if(table.Count() > 0)
                return await table.Skip(pageCount * (page - 1)).Take(pageCount).ToListAsync();
            return new List<T>();
        }

        public async Task<int> CountAllPage()
        {
            if (table.Count() > 0)
                return await table.CountAsync() / pageCount;
            return 0;
        }

        public void UpdatePageCount(int page)
        {
            pageCount = page;
        }
    }
}

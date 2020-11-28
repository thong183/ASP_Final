using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Reponsitory
{
    public class DataReponsitory<T> : IDataReponsitory<T> where T : class
    {
        protected DataContext _context;
        protected DbSet<T> table;

        public DataReponsitory(DataContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            await table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool Delete(T entity)
        {
            table.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteById(int Id)
        {
            var entity = table.Find(Id);
            if (entity == null) return false;
            return Delete(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await table.FindAsync(Id);
        }

        public bool IsExists(T entity)
        {
            return table.Find(entity) != null;
        }

        public async Task<T> Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}

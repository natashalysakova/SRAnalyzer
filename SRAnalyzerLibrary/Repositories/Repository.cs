using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SRAnalyzerLibrary.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        internal readonly DbContext _context;

        public Repository(SrAnalyzerDbContext context)
        {
            _context = context;
        }

        public int Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
            return item.Id;
        }

        public IEnumerable<int> AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                _context.Set<T>().Add(item);
            }

            _context.SaveChanges();

            return items.Select(x => x.Id);
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }


        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public abstract IEnumerable<T> GetAll();
    }
}

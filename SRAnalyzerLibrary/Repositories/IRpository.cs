using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SRAnalyzerLibrary.Repositories
{
    public interface IRepository<T> where T : class
    {
        int Add(T item);
        IEnumerable<int> AddRange(IEnumerable<T> items);


        T Get(int id);
        IEnumerable<T> GetAll();

        void Update(T item);
        void Delete(int id);
    }
}

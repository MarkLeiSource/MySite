using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDataFX
{
    public interface IRepository<T> : IDisposable where T : class, new()
    {
        List<T> GetList();

        List<T> GetList(Expression<Func<T, bool>> predicate);

        void Insert(T item, bool save = false);

        void Insert(List<T> items, bool save = false);

        void Delete(T item, bool save = false);

        void Delete(List<T> items, bool save = false);

        void Modify(T item, List<string> modifyProperties = null, bool save = false);
    }
}

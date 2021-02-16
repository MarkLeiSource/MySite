using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDataFX
{
    public abstract class Repository: IDisposable
    {
        public static Type DbContextType { get; set; }
        protected dynamic _context;
        public Repository()
        {
            _context = Activator.CreateInstance(DbContextType);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }

    public class Repository<T> : Repository, IRepository<T> where T : class, new()
    {
        public DbSet<T> DbSet
        {
            get
            {
                var p = DbContextType.GetProperty(typeof(T).Name);
                var dbSet = p.GetValue(_context);
                return ((DbSet<T>)dbSet);
            }
        }

        public List<T> GetList()
        {
            return DbSet.ToList();
        }

        public List<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public void Insert(T item, bool save = true)
        {
            DbSet.Add(item);
            SaveChanges(save);
        }

        public void Insert(List<T> items, bool save = true)
        {
            DbSet.AddRange(items);
            SaveChanges(save);
        }

        public void Delete(T item, bool save = true)
        {
            DbSet.Remove(item);
            SaveChanges(save);
        }

        public void Delete(List<T> items, bool save = true)
        {
            DbSet.RemoveRange(items);
            SaveChanges(save);
        }

        private void SaveChanges(bool save)
        {
            if (save)
            {
                ((DbContext)_context).SaveChanges();
            }
        }

        public void Modify(T item, List<string> modifyProperties = null, bool save = false)
        {
            var entry = ((DbContext)_context).Entry<T>(item);
            entry.State = EntityState.Modified;
            if (modifyProperties == null || modifyProperties.Count == 0)
            {
                DbSet.Attach(item);
            }
            else
            {
                foreach (var mp in modifyProperties)
                {
                    entry.Property(mp).IsModified = true;
                }
            }
            SaveChanges(save);
        }

        public List<K> SqlQuery<K>(string sql, params object[] parameters)
        {
            var result = ((DbContext)_context).Database.SqlQuery<K>(sql, parameters);
            return result.ToList();
        }


    }
}


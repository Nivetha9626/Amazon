using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Get(Expression<Func<T, bool>> filter);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter);

        T Insert(T entity);

        Task<T> InsertAsync(T entity);

        void InsertBulk(IEnumerable<T> entities);

        Task InsertBulkAsync(IEnumerable<T> entities);

        T Attach(T entity);

        void Update(T entity);

        void UpdateBulk(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteBulk(IEnumerable<T> entities);

        void DetachTracking(T entity);

        Task<TResult> QueryScalarAsync<TResult>(string query);

        Task<int> ExecuteSqlRawAsync(string sql, IEnumerable<SqlParameter> parameters);

        IQueryable<T> FromSqlInterpolated(FormattableString sql);

        IEnumerable<T> FromSqlRaw(string sql, object[] parameters);

        Task MigrateAsync();
    }
}

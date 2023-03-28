using Amazon.Interface;
using Amazon.Model.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrastructure
{
    //public class Repository<T> : IRepository<T> where T : BaseEntity
    //{
    //    private DbContext _dbContext { get; set; }
    //    protected DbSet<T> entities;
    //    public IApplicationDbContextFactory ContextFactory { get; set; }
    //    protected DbContext DbContext => _dbContext ??= ContextFactory.Get();

    //    public Repository(IApplicationDbContextFactory dbDbContextFactory)
    //    {
    //        ContextFactory = dbDbContextFactory;

    //        entities = DbContext.Set<T>();
    //    }

    //    public IEnumerable<T> GetAll()
    //    {
    //        return entities.AsQueryable();
    //    }

    //    public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
    //    {
    //        return entities.Where(filter);
    //    }

    //    public Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter)
    //    {
    //        var result = entities.Where(filter);
    //        return Task.FromResult((IEnumerable<T>)result.AsAsyncEnumerable());
    //    }

    //    public T Insert(T entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException(nameof(entity));
    //        }
    //        return entities.Add(entity).Entity;
    //    }

    //    public async Task<T> InsertAsync(T entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException(nameof(entity));
    //        }
    //        var result = await entities.AddAsync(entity);
    //        return result.Entity;
    //    }

    //    public void InsertBulk(IEnumerable<T> entities)
    //    {
    //        if (entities == null)
    //        {
    //            throw new ArgumentNullException(nameof(entities));
    //        }
    //        this.entities.AddRange(entities);
    //    }

    //    public async Task InsertBulkAsync(IEnumerable<T> entities)
    //    {
    //        if (entities == null)
    //        {
    //            throw new ArgumentNullException(nameof(entities));
    //        }
    //        await this.entities.AddRangeAsync(entities);
    //    }

    //    public T Attach(T entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException(nameof(entity));
    //        }
    //        entity = entities.Attach(entity).Entity;
    //        DbContext.Entry(entity).State = EntityState.Modified;

    //        return entity;
    //    }

    //    public void Update(T entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException(nameof(entity));
    //        }
    //        entities.Update(entity);
    //    }

    //    public void UpdateBulk(IEnumerable<T> entities)
    //    {
    //        if (entities == null)
    //        {
    //            throw new ArgumentNullException(nameof(entities));
    //        }
    //        this.entities.UpdateRange(entities);
    //    }

    //    public void Delete(T entity)
    //    {
    //        if (entity == null)
    //        {
    //            throw new ArgumentNullException(nameof(entity));
    //        }

    //        if (DbContext.Entry(entity).State == EntityState.Detached)
    //        {
    //            entities.Attach(entity);
    //        }
    //        entities.Remove(entity);
    //    }

    //    public void DeleteBulk(IEnumerable<T> entities)
    //    {
    //        if (entities == null)
    //        {
    //            throw new ArgumentNullException(nameof(entities));
    //        }
    //        this.entities.RemoveRange(entities);
    //    }

    //    public void DetachTracking(T entity)
    //    {
    //        DbContext.Entry(entity).State = EntityState.Detached;
    //    }

    //    public async Task<TResult> QueryScalarAsync<TResult>(string query)
    //    {
    //        using var command = _dbContext.Database.GetDbConnection().CreateCommand();
    //        command.CommandText = query;
    //        command.CommandType = System.Data.CommandType.Text;

    //        _dbContext.Database.OpenConnection();

    //        var val = await command.ExecuteScalarAsync();
    //        if (DBNull.Value.Equals(val))
    //        {
    //            val = null;
    //        }
    //        return (TResult)(val);
    //    }

    //    public async Task<int> ExecuteSqlRawAsync(string sql, IEnumerable<SqlParameter> parameters)
    //    {
    //        return await DbContext.Database.ExecuteSqlRawAsync(sql, parameters);
    //    }

    //    public IQueryable<T> FromSqlInterpolated(FormattableString sql)
    //    {
    //        return entities.FromSqlInterpolated(sql);
    //    }

    //    public IEnumerable<T> FromSqlRaw(string sql, object[] parameters)
    //    {
    //        return entities.FromSqlRaw(sql, parameters);
    //    }

    //    public async Task MigrateAsync()
    //    {
    //        await DbContext.Database.MigrateAsync();
    //    }
    //}

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private DbContext _dbContext { get; set; }
        protected DbSet<T> entities;
        public IApplicationDbContextFactory ContextFactory { get; set; }
        protected DbContext DbContext => _dbContext ??= ContextFactory.Get();
        public Repository(IApplicationDbContextFactory applicationDbContextFactory)
        {
                this.ContextFactory = applicationDbContextFactory;
                this.entities = DbContext.Set<T>();
            //this.entities = Dbcontext.Set<Prduct>();
            //this.entities =Dbset<Prdouct>
        }
        public T Attach(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
          entities.Remove(entity);
        }

        public void DeleteBulk(IEnumerable<T> entities)
        {
            this.entities.RemoveRange(entities);
        }

        public void DetachTracking(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteSqlRawAsync(string sql, IEnumerable<SqlParameter> parameters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FromSqlInterpolated(FormattableString sql)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FromSqlRaw(string sql, object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
        {
            return this.entities.Where(filter);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await this.entities.ToListAsync();
        }

        //getting entity on condtion based
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
          return  await this.entities.Where(filter).ToListAsync();
        }

        public T Insert(T entity)
        {
           return this.entities.Add(entity).Entity;
        }

        public async Task<T> InsertAsync(T entity)
        {
           return (await this.entities.AddAsync(entity)).Entity;
        }

        public void InsertBulk(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task InsertBulkAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task MigrateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TResult> QueryScalarAsync<TResult>(string query)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }

        public void UpdateBulk(IEnumerable<T> entities)
        {
            this.entities.UpdateRange(entities);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualBasic;
using Model.Interfaces;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DataProviderContext Db;
    protected readonly DbSet<TEntity> DbSet;
    public Repository(DataProviderContext context)
    {
        Db = context;
        DbSet = Db.Set<TEntity>();
     
    }

    public virtual async Task AddAsync(TEntity obj)
    {
        try
        {
            await DbSet.AddAsync(obj).ConfigureAwait(false);
        }
        catch (Exception exc)
        {
            throw;
        }
    }
    public virtual async Task<IEnumerable<TEntity>> AllAsync()
    {
        return await DbSet.ToListAsync().ConfigureAwait(false);
    }

    public virtual async Task<IEnumerable<TEntity>> AllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet
                    .Where(predicate)
                    .ToListAsync()
                    .ConfigureAwait(false);
    }

   
    public virtual async Task<TEntity> FindAsync(Guid id)
    {
        return await DbSet.FindAsync(id).ConfigureAwait(false);
    }
    public virtual async Task<IEnumerable<TEntity>> GetAllPaginaionAsync(Expression<Func<TEntity, bool>> predicate,
                                                                        int pageNumber = 1,
                                                                        int pageSize = 5)
    {
        return await DbSet
                          .Skip((pageNumber - 1) * pageSize)
                          .Take(pageSize)
                          .Where(predicate)
                          .ToListAsync().ConfigureAwait(false);
    }


    public int SaveChanges()
    {
        return Db.SaveChanges();
    }

    public virtual void Update(TEntity obj)
    {
        DbSet.Attach(obj);
        DbSet.Update(obj);
    }
    public virtual void Remove(Guid id)
    {
        DbSet.Remove(DbSet.Find(id));
    }

    public void Dispose()
    {
        Db.Dispose();
    }
}

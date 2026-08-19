using System.Linq.Expressions;

namespace Model.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    Task AddAsync(TEntity obj);
    Task<IEnumerable<TEntity>> AllAsync();
    Task<IEnumerable<TEntity>> AllAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> GetAllPaginaionAsync(Expression<Func<TEntity, bool>> predicate
                                                    , int pageNumber = 1
                                                    ,int pageSize = 5);
    Task<TEntity> FindAsync(Guid id);
    void Update(TEntity obj);
    void Remove(Guid id); 
    int SaveChanges();
}

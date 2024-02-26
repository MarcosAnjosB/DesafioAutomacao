using DesafioAutomacao.InfraStructure.InfraStructure.Repository;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DesafioAutomacao.InfraStructure.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IUnityOfWork UnitOfWork { get; }
        TEntity FindById(params object[] keyValues);
        IQueryable<TEntity> QueryableFor();
        IQueryable<TEntity> QueryableFor(Expression<Func<TEntity, bool>> criteria);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using DesafioAutomacao.InfraStructure.InfraStructure.Repository;


namespace DesafioAutomacao.InfraStructure.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IUnityOfWork UnitOfWork { get; private set; }

        IUnityOfWork IRepository<TEntity>.UnitOfWork => throw new NotImplementedException();

        #region Constructors
        public BaseRepository(IUnityOfWork unityOfWork)
        {
            UnitOfWork = unityOfWork;
        }

        #endregion

        public virtual IQueryable<TEntity> QueryableFor()
        {
            return UnitOfWork.QueryableFor<TEntity>();
        }

        public virtual IQueryable<TEntity> QueryableFor(Expression<Func<TEntity, bool>> criteria)
        {
            return UnitOfWork.QueryableFor<TEntity>(criteria);
        }

        public virtual TEntity FindById(params object[] keyValues)
        {
            return UnitOfWork.FindById<TEntity>(keyValues);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return UnitOfWork.Add(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return UnitOfWork.Update(entity);
        }

        public virtual TEntity Remove(TEntity entity)
        {
            return UnitOfWork.Remove(entity);
        }
    }
}

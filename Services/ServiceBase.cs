using Contracts;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositorybase;

        public ServiceBase(IRepositoryBase<T> repositorybase)
        {
            _repositorybase = repositorybase;
        }

        public void Create(T entity)
        {
            _repositorybase.Create(entity);
        }

        public void Delete(T entity)
        {
            _repositorybase.Delete(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return _repositorybase.FindAll(trackChanges);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return _repositorybase.FindByCondition(expression, trackChanges);
        }

        public void Update(T entity)
        {
            _repositorybase.Update(entity);
        }
    }
}

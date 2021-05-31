using FluentValidation.Results;
using ISAT.Developer.Exam.Core.Entities;
using ISAT.Developer.Exam.Core.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace ISAT.Developer.Exam.Core.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : BaseEntity<TEntity>
    {
        #region properties

        readonly IRepository<TEntity> _repository;

        #endregion

        #region ctor

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        #endregion

        #region methods

        public virtual ValidationResult Insert(TEntity entity)
        {
            if (!entity.IsValid()) return entity.ValidationResult;

            _repository.Insert(entity);

            return null;
        }

        public virtual ValidationResult Delete(long id)
        {
            _repository.Delete(id);

            return null;
        }

        public virtual ValidationResult Update(TEntity entity)
        {
            if (!entity.IsValid()) return entity.ValidationResult;

            _repository.Update(entity);

            return null;
        }

        public virtual TEntity GetById(long id)
        {

            return _repository.GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {

            return _repository.GetAll();
        }

        public virtual bool ExistsByExpression(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.ExistsByExpression(expression);
        }
        #endregion
    }
}
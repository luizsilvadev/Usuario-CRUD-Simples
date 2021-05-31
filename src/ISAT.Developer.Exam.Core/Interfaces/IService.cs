using FluentValidation.Results;
using ISAT.Developer.Exam.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ISAT.Developer.Exam.Core.Interfaces
{
    public interface IService<TEntity> where TEntity : BaseEntity<TEntity>
    {
        ValidationResult Insert(TEntity entity);

        ValidationResult Delete(long id);

        ValidationResult Update(TEntity entity);

        TEntity GetById(long id);

        IEnumerable<TEntity> GetAll();

        bool ExistsByExpression(Expression<Func<TEntity, bool>> expression);
    }
}
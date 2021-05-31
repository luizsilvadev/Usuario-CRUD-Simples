using FluentValidation.Results;
using ISAT.Developer.Exam.Core.Entities;
using System.Collections.Generic;

namespace ISAT.Developer.Exam.Core.Interfaces
{
    public interface IService<TEntity> where TEntity : BaseEntity<TEntity>
    {
        ValidationResult Insert(TEntity entity);

        ValidationResult Delete(long id);

        ValidationResult Update(TEntity entity);

        TEntity GetById(long id);

        IEnumerable<TEntity> GetAll();
    }
}
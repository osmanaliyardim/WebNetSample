﻿using System.Linq.Expressions;
using WebNetSample.Core.Entities;

namespace WebNetSample.Core.DataAccess;

public interface IEntityRepository<T> where T : BaseEntity
{

    Task<T> GetAsync(Expression<Func<T, bool>> filter);

    Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(Expression<Func<T, bool>> filter);

}
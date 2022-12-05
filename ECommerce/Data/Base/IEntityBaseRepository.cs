﻿using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerce.Data.Base
{
    public interface IEntityBaseRepository <T> where T : class, IBaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>> [] include);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id ,params Expression<Func<T, object>>[] include);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SaveChanges();
    }
}

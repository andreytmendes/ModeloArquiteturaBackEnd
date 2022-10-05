﻿using FluentValidation;
using Lideranca.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lideranca.Data.Domain.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> GetAsync(long id);
        Task<IEnumerable<T>> GetListAsync();
        Task<T> InsertAsync<TValidator>(T entity) where TValidator : AbstractValidator<T>;
        Task<T> UpdateAsync<TValidator>(T entity) where TValidator : AbstractValidator<T>;
        Task DeleteAsync(long id);
    }
}

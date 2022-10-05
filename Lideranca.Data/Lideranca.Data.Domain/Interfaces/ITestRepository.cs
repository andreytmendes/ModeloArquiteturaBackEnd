using Lideranca.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lideranca.Data.Domain.Interfaces
{
    public interface ITestRepository : IBaseRepository<TestEntity>
    {
        Task<string> GetTextAsync(long Id);
    }
}

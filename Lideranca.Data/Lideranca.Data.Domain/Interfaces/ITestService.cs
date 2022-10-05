using Lideranca.Data.Domain.DTOs;
using Lideranca.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lideranca.Data.Domain.Interfaces
{
    public interface ITestService : IBaseService<TestEntity>
    {
        Task<string> GetTextAsync(long id);
        Task<TestDTO> GetTestAsync(long id);
        Task InsertTestAsync(TestDTO testDTO);
        Task InsertTestOtherAsync(TestOtherDTO testOtherDTO);
        Task UpdateTestAsync(TestUpdateDTO testUpdateDTO);
    }
}

using Lideranca.Data.Data.Context;
using Lideranca.Data.Domain.Entities;
using Lideranca.Data.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lideranca.Data.Data.Repositories
{
    public class TestRepository : BaseRepository<TestEntity>, ITestRepository
    {
        private readonly DbSet<TestEntity> _testEntity;

        public TestRepository(AutenticationContext context) : base(context)
        {
            _testEntity = context.Set<TestEntity>();
        }

        public async Task<string> GetTextAsync(long Id)
        {
            var test = await this.GetAsync(Id);
            return test != null ? test.Text : null;
        }
    }
}

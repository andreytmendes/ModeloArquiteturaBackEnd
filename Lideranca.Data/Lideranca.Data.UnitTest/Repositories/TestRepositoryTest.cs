using Lideranca.Data.Data.Repositories;
using Lideranca.Data.Domain.Entities;
using Lideranca.Data.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lideranca.Data.UnitTest.Repositories
{
    public class TestRepositoryTest : IClassFixture<HandlerServiceTest>
    {
        private IServiceProvider _serviceProviderMock;
        private readonly ITestRepository _testRepository;

        public TestRepositoryTest(HandlerServiceTest fixture)
        {
            _serviceProviderMock = fixture.ServiceProviderMock;
            var scope = _serviceProviderMock.CreateScope();
            _testRepository = scope.ServiceProvider.GetService<ITestRepository>();
        }

        [Fact]
        public async Task GetEntity()
        {
            //Act
            var result = await _testRepository.GetAsync(1);
            
            //Assert
            Assert.IsType<TestEntity>(result);
        }
    }
}

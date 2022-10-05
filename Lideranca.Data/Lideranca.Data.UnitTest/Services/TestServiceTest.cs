using Lideranca.Data.Domain.Entities;
using Lideranca.Data.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Lideranca.Data.UnitTest.Services
{
    public class TestServiceTest : IClassFixture<HandlerServiceTest>
    {
        private IServiceProvider _serviceProviderMock;
        private readonly ITestService _testService;

        public TestServiceTest(HandlerServiceTest fixture)
        {
            _serviceProviderMock = fixture.ServiceProviderMock;
            var scope = _serviceProviderMock.CreateScope();
            _testService = scope.ServiceProvider.GetService<ITestService>();
        }

        [Fact]
        public async Task GetEntity()
        {
            //Act
            var result = await _testService.GetTextAsync(1);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task InsertEntity()
        {
            //Arrange
            var entity = new TestEntity()
            {
                Text = "Text Test",
                Observacao = "Observação",
                DateRegister = DateTime.Now,
                DateLastUpdate = DateTime.Now
            };

            //Act
            var result = await _testService.InsertAsync<TestValidator>(entity);

            //Assert
            Assert.True(result.Id > 0);
        }
    }
}

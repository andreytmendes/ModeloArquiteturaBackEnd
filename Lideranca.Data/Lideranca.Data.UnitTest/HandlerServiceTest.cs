using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Lideranca.Data.Data.Context;
using Lideranca.Data.Domain.Interfaces;
using Lideranca.Data.Data.Repositories;
using Lideranca.Data.Domain.Entities;
using Lideranca.Data.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Lideranca.Data.UnitTest
{
    public class HandlerServiceTest
    {
        public IServiceProvider ServiceProviderMock { get; set; }

        public HandlerServiceTest() : base()
        {
            var config = new ConfigurationBuilder()
                   .SetBasePath(AppContext.BaseDirectory)
                   .AddJsonFile("appsettings.json", optional: false)
                   .AddEnvironmentVariables()
                   .Build();

            ServiceProviderMock = new ServiceCollection()
                      .AddSingleton<IConfiguration>(config)
                      .AddSingleton<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>()
                      .AddSingleton<ITestRepository, TestRepository>()
                      .AddSingleton<IBaseService<BaseEntity>, BaseService<BaseEntity>>()
                      .AddSingleton<ITestService, TestService>()
                      .AddSingleton<ILoggerFactory, NullLoggerFactory>()
                      .AddSingleton<AutenticationContext>()
                      //.AddSingleton(GetConfiguration())
                      .AddLogging()
                      .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                      .AddDbContext<AutenticationContext>(options => options.UseSqlServer(config.GetSection("ConnectionString").Value))
                      .BuildServiceProvider();
        }

        private IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}

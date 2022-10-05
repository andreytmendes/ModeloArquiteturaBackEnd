using Lideranca.Data.Domain.Entities;
using Lideranca.Data.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Lideranca.Data.Domain.DTOs;
using AutoMapper;

namespace Lideranca.Data.Service.Services
{
    public class TestService : BaseService<TestEntity>, ITestService
    {
        private readonly ILogger<TestService> _logger;
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestService(ILogger<TestService> logger, ITestRepository testRepository, IMapper mapper) : base(testRepository)
        {
            _logger = logger;
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<string> GetTextAsync(long id)
        {
            try
            {
                return await _testRepository.GetTextAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error GetTestAsync: {JsonConvert.SerializeObject(ex)}");
                throw;
            }
        }

        public async Task<TestDTO> GetTestAsync(long id)
        {
            try
            {
                var testEntity = await _testRepository.GetAsync(id);

                var testDto = new TestDTO();
                _mapper.Map(testEntity, testDto);
                return testDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error GetTestAsync: {JsonConvert.SerializeObject(ex)}");
                throw;
            }
        }

        public async Task InsertTestAsync(TestDTO testDTO)
        {
            try
            {
                var testEntity = new TestEntity();
                _mapper.Map(testDTO, testEntity);
                await this.InsertAsync<TestValidator>(testEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error InsertTestAsync: {JsonConvert.SerializeObject(ex)}");
                throw;
            }
        }

        public async Task InsertTestOtherAsync(TestOtherDTO testOtherDTO)
        {
            try
            {
                var testEntity = new TestEntity();
                _mapper.Map(testOtherDTO, testEntity);
                await this.InsertAsync<TestValidator>(testEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error InsertTestOtherAsync: {JsonConvert.SerializeObject(ex)}");
                throw;
            }
        }

        public async Task UpdateTestAsync(TestUpdateDTO testDTO)
        {
            try
            {
                var testEntity = new TestEntity();
                _mapper.Map(testDTO, testEntity);
                testEntity.Id = testDTO.Id;

                await this.UpdateAsync<TestValidator>(testEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error UpdateTestAsync: {JsonConvert.SerializeObject(ex)}");
                throw;
            }
        }

    }
}
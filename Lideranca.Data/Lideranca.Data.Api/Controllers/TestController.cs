using System;
using System.Threading.Tasks;
using Lideranca.Data.Domain.DTOs;
using Lideranca.Data.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Lideranca.Data.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        [Route("get")]
        [SwaggerOperation("Get OK")]
        public string Get() => "OK";

        [HttpGet]
        [Route("getText")]
        [SwaggerOperation("Get an text")]
        public async Task<IActionResult> GetText(long id)
        {
            try
            {
                var retorno = await _testService.GetTextAsync(id);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getTest")]
        [SwaggerOperation("Get test")]
        public async Task<IActionResult> GetTest(long id)
        {
            try
            {
                var retorno = await _testService.GetTestAsync(id);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("insertTest")]
        [SwaggerOperation("Insert Test")]
        public async Task<IActionResult> InsertTest([FromBody]TestDTO testDTO)
        {
            try
            {
                await _testService.InsertTestAsync(testDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("insertTestOther")]
        [SwaggerOperation("Insert Test Other")]
        public async Task<IActionResult> InsertTestOther([FromBody]TestOtherDTO testOtherDTO)
        {
            try
            {
                await _testService.InsertTestOtherAsync(testOtherDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("updateTest")]
        [SwaggerOperation("Update Test")]
        public async Task<IActionResult> UpdateTest([FromBody]TestUpdateDTO testUpdateDTO)
        {
            try
            {
                await _testService.UpdateTestAsync(testUpdateDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteTest")]
        [SwaggerOperation("Delete Test")]
        public async Task<IActionResult> DeleteTest(long id)
        {
            try
            {
                await _testService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

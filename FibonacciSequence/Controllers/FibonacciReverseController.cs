using FibonacciSequence.Business.Services.Interfaces;
using FibonacciSequence.Data.Models;
using FibonacciSequence.Data.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FibonacciSequence.Api.Controllers
{
    [Route("api/fibonacciReverse")]
    [ApiController]
    public class FibonacciReverseController : ControllerBase
    {
        private readonly IFibonacciNumberSetService _setService;
        private readonly IMongoDBService _mongoDBService;

        public FibonacciReverseController(IFibonacciNumberSetService setService, IMongoDBService mongoDBService)
        {
            _setService = setService;
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        [Route("getAll")]
        public List<FibonacciNumberSequence> GetAll() =>
            _mongoDBService.Get();


        [HttpGet("getById")]
        public ActionResult<FibonacciNumberSequence> GetById(string id)
        {
            var set = _mongoDBService.Get(id);

            if (set == null)
            {
                return NotFound();
            }

            return set;
        }

        [HttpGet("getAllReverse")]
        public List<FibonacciNumberSequenceReverse> GetAllReverse() =>
            _mongoDBService.GetReverse();


        [HttpGet("getByIdReverse")]
        public ActionResult<FibonacciNumberSequenceReverse> GetByIdReverse(string id)
        {
            var set = _mongoDBService.GetReverse(id);

            if (set == null)
            {
                return NotFound();
            }

            return set;
        }


        [HttpPost("create")]
        public async Task<ActionResult<FibonacciNumberSequenceReverse>> CreateAsync(CreateFibonacciSequenceDto set)
        {
            var result = await _setService.CreateAsync(set);
            if (result.Error == null)
            {
                return Ok(result.Data);
            }
            else return BadRequest(result.Error);
        }

    }
}

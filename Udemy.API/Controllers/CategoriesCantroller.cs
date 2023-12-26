using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Business.DTOs.CategoryDtos;
using Udemy.Business.Exceptions.Common;
using Udemy.Business.Services.Interfaces;

namespace Udemy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesCantroller : ControllerBase
    {
        private readonly ICategoryservice _service;

        public CategoriesCantroller(ICategoryservice service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _service.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK,categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto createDto)
        {
            try
            {
                var result = await _service.CreateAsync(createDto);

                return Ok(result);
            }
            catch (NegativeIdException message)
            {
                return StatusCode(StatusCodes.Status200OK, message.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> ReadId(int id)
        {
            var result = await _service.GetById(id);
            return StatusCode(StatusCodes.Status200OK);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CategoryUpdateDtos category)
        {
            var result = await _service.UpdateAsync(category);
            return StatusCode(StatusCodes.Status200OK);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] int Id)
        {
            var result = await _service.DeleteAsync(Id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}

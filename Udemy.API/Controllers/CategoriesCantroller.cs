using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.Business.DTOs.CategoryDtos;
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
            var categories=_service.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK,categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto createDto)
        {
            bool result=await _service.CreateAsync(createDto);
            if(result) return StatusCode(StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status409Conflict);
        }
    }
}

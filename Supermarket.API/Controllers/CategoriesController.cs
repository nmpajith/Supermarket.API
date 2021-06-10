using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.DataTransferObjects;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category = _mapper.Map<CreateCategoryDto, Category>(categoryDto);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResposeDto = _mapper.Map<Category, CategoryDto>(result.Resource);
            return Ok(categoryResposeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<CreateCategoryDto, Category>(createCategoryDto);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryDto>(result.Resource);
            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryDto>(result.Resource);
            return Ok(categoryResource);
        }
    }
}
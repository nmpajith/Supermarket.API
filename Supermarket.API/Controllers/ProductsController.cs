using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.DataTransferObjects;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Models.Queries;
using Supermarket.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [Route("/api/products")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all existing products.
        /// </summary>
        /// <returns>List of products.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(QueryResultDto<ProductDto>), 200)]
        public async Task<QueryResultDto<ProductDto>> ListAsync([FromQuery] ProductsQueryDto query)
        {
            var productsQuery = _mapper.Map<ProductsQueryDto, ProductsQuery>(query);
            var queryResult = await _productService.ListAsync(productsQuery);

            var resource = _mapper.Map<QueryResult<Product>, QueryResultDto<ProductDto>>(queryResult);
            return resource;
        }

        /// <summary>
        /// Saves a new product.
        /// </summary>
        /// <param name="resource">Product data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), 201)]
        [ProducesResponseType(typeof(ErrorDto), 400)]
        public async Task<IActionResult> PostAsync([FromBody] CreateProductDto resource)
        {
            var product = _mapper.Map<CreateProductDto, Product>(resource);
            var result = await _productService.SaveAsync(product);

            if (!result.Success)
            {
                return BadRequest(new ErrorDto(result.Message));
            }

            var productResource = _mapper.Map<Product, ProductDto>(result.Resource);
            return Ok(productResource);
        }

        /// <summary>
        /// Updates an existing product according to an identifier.
        /// </summary>
        /// <param name="id">Product identifier.</param>
        /// <param name="resource">Product data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductDto), 201)]
        [ProducesResponseType(typeof(ErrorDto), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateProductDto resource)
        {
            var product = _mapper.Map<CreateProductDto, Product>(resource);
            var result = await _productService.UpdateAsync(id, product);

            if (!result.Success)
            {
                return BadRequest(new ErrorDto(result.Message));
            }

            var productResource = _mapper.Map<Product, ProductDto>(result.Resource);
            return Ok(productResource);
        }

        /// <summary>
        /// Deletes a given product according to an identifier.
        /// </summary>
        /// <param name="id">Product identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProductDto), 200)]
        [ProducesResponseType(typeof(ErrorDto), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorDto(result.Message));
            }

            var categoryResource = _mapper.Map<Product, ProductDto>(result.Resource);
            return Ok(categoryResource);
        }
    }
}

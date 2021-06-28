using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsTypesController: ControllerBase
    {
        private readonly ProductTypeService _service;
        public ProductsTypesController(ProductTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<ProductType>>> GetAsync()
        {
            var response = await _service.GetProductsTypesAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductType>>> GetByIdAsync(string id)
        {
            var response = await _service.GetBySubCategoryIdAsync(id);
            return Ok(response);
        }
    }
}
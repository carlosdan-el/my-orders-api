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
    public class ProductsModelsController: ControllerBase
    {
        private readonly ProductModelService _service;
        public ProductsModelsController(ProductModelService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<ProductModel>>> GetAsync()
        {
            var response = await _service.GetProductsModelsAsync();
            return Ok(response);
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<List<ProductModel>>> GetByIdAsync(string id)
        {
            var response = await _service.GetProductsModelsByTypeIdAsync(id);
            return Ok(response);
        }
    }
}
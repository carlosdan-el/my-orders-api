using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                string view = HttpContext.Request.Query["view"].ToString();
                
                if(view == "Report") {
                    return Ok(await _service.GetProductsToReportAsync());
                }

                return Ok(await _service.GetProductsAsync());
            }
            catch(Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var response = await _service.GetProductByIdAsync(id);

            return Ok(response);

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            try{
                
                if(String.IsNullOrEmpty(product.UpdatedBy))
                {
                    product.UpdatedBy = "1";
                }

                if(String.IsNullOrEmpty(product.Name) || String.IsNullOrEmpty(product.CategoryId)
                || product.Price <= 0 || String.IsNullOrWhiteSpace(product.SubCategoryId))
                {
                    throw new InvalidOperationException("Todos os campos obrigatórios devem ser preenchidos.");
                }

                await _service.CreateProductAsync(product);

                return NoContent();
            }
            catch(InvalidOperationException error)
            {
                return BadRequest(new { 
                    error = error.Message,
                    source = error.Source,
                    stackTrace = error.StackTrace
                });
            }
            catch(Exception error)
            {
                return BadRequest(new { 
                    error = error.Message,
                    source = error.Source,
                    stackTrace = error.StackTrace
                });
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Product>> Update([FromBody] Product product)
        {
            try
            {
                if(String.IsNullOrEmpty(product.UpdatedBy))
                {
                    product.UpdatedBy = "1";
                }

                if(String.IsNullOrEmpty(product.Name) || String.IsNullOrEmpty(product.CategoryId)
                || product.Price <= 0 || String.IsNullOrWhiteSpace(product.SubCategoryId))
                {
                    throw new InvalidOperationException("Todos os campos obrigatórios devem ser preenchidos.");
                }

                await _service.UpdateProductAsync(product);

                return NoContent();
            }
            catch(InvalidOperationException error)
            {
                return BadRequest(new { 
                    error = error.Message,
                    source = error.Source,
                    stackTrace = error.StackTrace
                });
            }
            catch(Exception error)
            {
                return BadRequest(new { 
                    error = error.Message,
                    source = error.Source,
                    stackTrace = error.StackTrace
                });
            }
        }
    }
}

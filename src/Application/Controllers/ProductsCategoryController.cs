using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Services;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsCategoryController: ControllerBase
    {
        private readonly ProductCategoryService _service;

        public ProductsCategoryController(ProductCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<ProductCategory>>> GetAsync([FromQuery] string id)
        {
            try
            {
                if(!String.IsNullOrEmpty(id))
                {
                    var response = await _service.GetProductCategoryByIdAsync(id);
                    return Ok(JsonResponseRequest.Success(response, 200));
                }
                else
                {
                    var response = await _service.GetAllProductsCategoryAsync();
                    return Ok(JsonResponseRequest.Success(response, 200));
                }
            }
            catch(Exception error)
            {
                return BadRequest(JsonResponseRequest.Error(error.Message, 400, error.ToString()));
            }
        }
 
    }
}
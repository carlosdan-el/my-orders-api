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
    public class SubCategoriesController: ControllerBase
    {
        private readonly SubCategoryService _service;
        public SubCategoriesController(SubCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<SubCategory>>> GetAsync()
        {
            var response = await _service.GetCategoriesAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SubCategory>>> GetByCategoryAsync(string id)
        {
            var response = await _service.GetByCategoryIdAsync(id);
            return Ok(response);
        }
    }
}
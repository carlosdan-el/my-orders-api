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
    public class CategoriesController: ControllerBase
    {
        private readonly CategoryService _service;
        public CategoriesController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> GetAsync()
        {
            var response = await _service.GetCategoriesAsync();
            return Ok(response);
        }
    }
}
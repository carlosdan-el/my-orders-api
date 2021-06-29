using System;
using System.Linq;
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
    public class OrdersController: ControllerBase
    {
        private readonly OrderService _service;
        public OrdersController(OrderService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                var response = await _service.GetOrdersAsync();
                return Ok(response);
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
    
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(string id)
        {
            try
            {
                var response = await _service.GetOrderByIdAsync(id);
                return Ok(response);
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
    
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Post([FromBody] List<ProductsOrder> products)
        {
            try
            {
                List<object> data = new List<object>();
                var order = new {
                    Id = Guid.NewGuid().ToString(),
                    UserId = "1",
                    Price = products.Where(x => x.Price >= 0)
                    .Select(x => x.Price).Sum()
                };

                products.ForEach(x => {
                    data.Add(new {
                        OrderId = order.Id,
                        ProductId = x.ProductId,
                        Quantity = x.Quantity
                    });
                });

                await _service.CreateOrder(order, data);
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
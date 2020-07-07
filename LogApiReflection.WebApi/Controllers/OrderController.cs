using System.Linq;
using System.Text.Json;
using LogApiReflection.Domain;
using LogApiReflection.Services;
using LogApiReflection.Services.Orders;
using Microsoft.AspNetCore.Mvc;

namespace LogApiReflection.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _orderService.GetAll();

            if (!result.Any()) return BadRequest("Nenhum registro encontrado!");
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _orderService.GetById(id);

            if (result == null) return BadRequest("Registro não encontrado!");
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] JsonElement json)
        {
            var book = JsonSerializer.Deserialize<Order>(json.ToString());
            var response = _orderService.Add(book);
            if (response == 0) return NoContent();
            return Ok(response);
        }
    }
}
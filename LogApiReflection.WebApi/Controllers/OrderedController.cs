using System.Linq;
using LogApiReflection.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogApiReflection.Controllers
{
    [Route("api/[controller]")]
    public class OrderedController : Controller
    {
        private readonly IOrderedService _orderedService;

        public OrderedController(IOrderedService orderedService)
        {
            _orderedService = orderedService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _orderedService.GetAll();

            if (!result.Any()) return BadRequest("Nenhum registro encontrado!");
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _orderedService.GetById(id);

            if (result == null) return BadRequest("Registro não encontrado!");
            return Ok(result);
        }
    }
}
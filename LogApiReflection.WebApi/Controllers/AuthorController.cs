using System.Linq;
using System.Text.Json;
using LogApiReflection.Domain;
using LogApiReflection.Services.Authors;
using Microsoft.AspNetCore.Mvc;

namespace LogApiReflection.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _authorService.GetAll();

            if (!result.Any()) return BadRequest("Nenhum registro encontrado!");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _authorService.GetById(id);

            if (result == null) return BadRequest("Registro não encontrado!");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] JsonElement json)
        {
            var author = JsonSerializer.Deserialize<Author>(json.ToString());
            var response = _authorService.Add(author);
            if (response == 0) return NoContent();
            return Ok(response);
        }
    }
}
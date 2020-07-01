using System.Linq;
using System.Text.Json;
using LogApiReflection.Domain;
using LogApiReflection.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace LogApiReflection.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _bookService.GetAll();

            if (!result.Any()) return BadRequest("Nenhum registro encontrado!");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _bookService.GetById(id);

            if (result == null) return BadRequest("Registro não encontrado!");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] JsonElement json)
        {
            var book = JsonSerializer.Deserialize<Book>(json.ToString());
            var response = _bookService.Insert(book);
            return Ok(response);
        }
    }
}
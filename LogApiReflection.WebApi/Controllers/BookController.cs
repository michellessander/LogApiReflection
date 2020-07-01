using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using LogApiReflection.Domain;
using LogApiReflection.Services.Books;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        // [HttpPost]
        // public IActionResult Post(Book book)
        // {
        //     // var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(obj.ToString());
        //     // var response = await _bookService.Insert(dict);
        //     var response = _bookService.Insert(book);
        //     return Ok(response);
        // }
    }
}
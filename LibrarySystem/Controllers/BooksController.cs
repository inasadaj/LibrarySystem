using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem.Data.Models;
using LibrarySystem.Data.VM;
using LibrarySystem.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        readonly IBookService _bookService;
        public BooksController(IBookService service)
        {
            _bookService = service;
        }
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.Books();
        }

        // GET api/values/5
        [HttpGet("{title}")]
        public Book Get(string title)
        {
            return _bookService.GetBookByTitle(title);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] BookVM book)
        {
            return _bookService.CreateBook(book);
        }

        // PUT api/values/5
        [HttpPut]
        public string Put([FromBody] BookVM book)
        {
            return _bookService.UpdateBook(book);
        }

        // DELETE api/values/5
        [HttpDelete("{title}")]
        public string Delete(string title)
        {
            return _bookService.DeleteBook(title);
        }
    }
}


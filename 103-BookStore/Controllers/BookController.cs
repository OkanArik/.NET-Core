using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookQuery;
using WebApi.BookOperations.UpdateBook;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context=context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery Query = new GetBooksQuery(_context);
            var result= Query.Handle();
            return Ok(result);
        }
        

        
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            GetBookQuery Query = new GetBookQuery(_context);
            try
            {
                var result=Query.Handle(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost] 
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model=newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromBody] UpdateBookModel updatedBook, int id)
        {
            
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.Model=updatedBook;
                command.Handle(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book=_context.Books.SingleOrDefault(x=> x.Id==id);

            if(book is null)
              return BadRequest();
            
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
        
    }
}
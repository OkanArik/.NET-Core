using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.DeleteBook;

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
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery Query = new GetBookDetailQuery(_context);
                Query.BookId=id;
                result=Query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
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
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.Model=updatedBook;
                command.Handle();
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
            try
            {
                DeleteBookCommand command =new DeleteBookCommand(_context);
                command.BookId=id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        
    }
}
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
using AutoMapper;
using FluentValidation.Results;
using FluentValidation;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery Query = new GetBooksQuery(_context,_mapper);
            var result= Query.Handle();
            return Ok(result);
        }
        

        
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
                BookDetailViewModel result;

                GetBookDetailQuery Query = new GetBookDetailQuery(_context,_mapper);
                Query.BookId=id;
                GetBookDetailQueryValidator validator=new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(Query);
                result=Query.Handle();

                return Ok(result);
        }
        
        [HttpPost] 
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
                command.Model=newBook;
                
                CreateBookCommandValidator  validator= new CreateBookCommandValidator(); 
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromBody] UpdateBookModel updatedBook, int id)
        {
 
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.Model=updatedBook;
                command.BookId=id;
                UpdateBookCommandValidator validator= new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                
                return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
                DeleteBookCommand command =new DeleteBookCommand(_context);
                command.BookId=id;
                DeleteBookCommandValidator validator =new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

                return Ok();
        }
        
    }
}
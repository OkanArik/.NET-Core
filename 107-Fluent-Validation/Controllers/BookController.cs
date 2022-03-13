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
            try
            {
                GetBookDetailQuery Query = new GetBookDetailQuery(_context,_mapper);
                Query.BookId=id;
                GetBookDetailQueryValidator validator=new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(Query);
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
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            try
            {
                command.Model=newBook;
                
                CreateBookCommandValidator  validator= new CreateBookCommandValidator(); 
                validator.ValidateAndThrow(command);
                // Aşağıdaki kullanım User Friendly olmadığı için bunu tercih etmeyiz çünkü UI' BadRequest() dönmez hata durumunda aslına baktığımız zaman çalışır hatalı durumda db ye içeriği post etmez fakat bu UI da anlaşılamayabilir.
                // ValidationResult result=validator.Validate(command);//ValidationResult class'ı FluentValidation.Result namespace'i altından gelmektedir.
                // if(!result.IsValid)
                //     foreach (var item in result.Errors)//Burada validation dan geçmeyen property ve onların hata mesajlarının console 'a yazdırdık.
                //     {
                //         Console.WriteLine(" Property: "+item.    PropertyName+" - Error Message: "+item.    ErrorMessage);
                //     }
                //else
                //  command.Handle();
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
                command.BookId=id;
                UpdateBookCommandValidator validator= new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
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
                DeleteBookCommandValidator validator =new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
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
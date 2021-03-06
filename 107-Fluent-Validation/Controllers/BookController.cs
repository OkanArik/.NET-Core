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
                // A??a????daki kullan??m User Friendly olmad?????? i??in bunu tercih etmeyiz ????nk?? UI' BadRequest() d??nmez hata durumunda asl??na bakt??????m??z zaman ??al??????r hatal?? durumda db ye i??eri??i post etmez fakat bu UI da anla????lamayabilir.
                // ValidationResult result=validator.Validate(command);//ValidationResult class'?? FluentValidation.Result namespace'i alt??ndan gelmektedir.
                // if(!result.IsValid)
                //     foreach (var item in result.Errors)//Burada validation dan ge??meyen property ve onlar??n hata mesajlar??n??n console 'a yazd??rd??k.
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
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using WebApi.Applications.BookOperations.Queries.GetBooks;
using WebApi.Applications.BookOperations.Commands.CreateBook;
using WebApi.Applications.BookOperations.Commands.UpdateBook;
using WebApi.Applications.BookOperations.Queries.GetBookDetail;
using WebApi.Applications.BookOperations.Commands.DeleteBook;
using AutoMapper;
using FluentValidation.Results;
using FluentValidation;
using WebApi.Applications.GenreOperations.Queries.GetAuthors;
using WebApi.Applications.GenreOperations.Queries.GetAuthorDetail;
using Webapi.Applications.AuthorOperations.Commands.CreateAuthor;
using WebApi.Applications.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Applications.AuthorOperations.Commands.DeleteAuthor;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class AuthorController:ControllerBase
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery Query = new GetAuthorsQuery(_dbContext,_mapper);
            var result = Query.Handle(); 
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorDetail(int id)
        {
            AuthorDetailViewModel result;

            GetAuthorDetailQuery Query = new GetAuthorDetailQuery (_dbContext,_mapper);
            Query.AuthorId=id;

            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
            validator.ValidateAndThrow(Query);
            result = Query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command =new CreateAuthorCommand(_dbContext,_mapper);
            command.Model=newAuthor;

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id,[FromBody] UpdateAuthorModel updatedAuthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand (_dbContext);
            command.AuthorId=id;
            command.Model=updatedAuthor;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_dbContext);
            command.AuthorId=id;

            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        } 
    }
}
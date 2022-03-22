using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace Webapi.Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;
        public CreateAuthorModel Model{get;set;}

        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
           var author = _context.Authors.SingleOrDefault(x=> x.Name==Model.Name && x.SurName==Model.SurName && x.dateOfBirth==Model.dateOfBirth);
           if(author is not null)
             throw new InvalidOperationException("Yazar zaten mevcut!");
            
           author = _mapper.Map<Author>(Model);
           _context.Add(author);
           _context.SaveChanges();
        }
    }
    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string SurName { get; set; }
    }
}
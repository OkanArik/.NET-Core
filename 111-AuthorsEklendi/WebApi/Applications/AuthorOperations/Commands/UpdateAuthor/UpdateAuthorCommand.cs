using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }

        public UpdateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _context;

        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Id==AuthorId);
            if(author is null)
               throw new InvalidOperationException("Yazar mevcut değil!");
            
            author.Name = Model.Name!=default ? Model.Name : author.Name;
            author.SurName = Model.SurName!=default ? Model.SurName : author.SurName;
            author.dateOfBirth = Model.dateOfBirth!=default ? Model.dateOfBirth : author.dateOfBirth;
            
            _context.SaveChanges();
        }
    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime dateOfBirth { get; set; }
    }
}
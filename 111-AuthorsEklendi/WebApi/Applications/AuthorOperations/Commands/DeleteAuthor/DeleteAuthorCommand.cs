using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }

        private readonly BookStoreDbContext _context;

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Id==AuthorId);
            if(author is null)
              throw new InvalidOperationException("Yazar bulunamadı!");
            else if(_context.Books.FirstOrDefault(x=> x.AuthorId==author.Id) is not null)
              throw new InvalidOperationException("Kitabı yayında olan yazar silinemez!");
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
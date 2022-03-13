using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using WebApi.Common;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public BookDetailViewModel Handle()
        {
             var book = _dbContext.Books.Where(x=> x.Id==BookId).SingleOrDefault();

             if(book is null)
               throw new InvalidOperationException("Kitap mevcut değil!");
            
             BookDetailViewModel bvm =new BookDetailViewModel ();
             bvm.Title=book.Title;
             bvm.Genre=((GenreEnum)book.GenreId).ToString();
             bvm.PageCount=book.PageCount;
             bvm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy");
             
             return bvm;
        }
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
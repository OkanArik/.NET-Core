using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using WebApi.Common;

namespace WebApi.BookOperations.GetBookQuery
{
    public class GetBookQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBookQuery(BookStoreDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public BookViewModel Handle(int id)
        {
             var book = _dbContext.Books.Where(x=> x.Id==id).SingleOrDefault();

             if(book is null)
               throw new InvalidOperationException("Kitap mevcut değil!");
            
             BookViewModel bvm =new BookViewModel ();
             bvm.Title=book.Title;
             bvm.Genre=((GenreEnum)book.GenreId).ToString();
             bvm.PageCount=book.PageCount;
             bvm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy");
             
             return bvm;
        }
    }
    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
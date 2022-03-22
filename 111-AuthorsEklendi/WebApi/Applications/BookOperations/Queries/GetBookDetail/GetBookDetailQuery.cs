using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using WebApi.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Applications.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
             var book = _dbContext.Books.Include(x=> x.Genre).Include(x=> x.Author).Where(x=> x.Id==BookId).SingleOrDefault();

             if(book is null)
               throw new InvalidOperationException("Kitap mevcut değil!");

            BookDetailViewModel bvm =_mapper.Map<BookDetailViewModel>(book);//book objesi ile gelen veriyi BookViewModel objesine convert ettik ve bvm objesine assign ettik.
            return bvm;
        }
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string AuthorNameSurname { get; set; }
        public string Genre { get; set; }
    }
}
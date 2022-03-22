using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Applications.GenreOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public readonly  BookStoreDbContext _context;
        public readonly  IMapper _mapper;
        public int AuthorId { get; set; }
        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Id==AuthorId);
            if(author is null)
              throw new InvalidOperationException("Aradığınız yazar mevcut değil!");
            return _mapper.Map<AuthorDetailViewModel>(author);
        }
    }

    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string  dateOfBirth {get; set;}
    }
}
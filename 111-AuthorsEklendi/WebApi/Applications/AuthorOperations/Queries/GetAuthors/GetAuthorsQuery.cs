using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Applications.GenreOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        public readonly  BookStoreDbContext _context;
        public readonly  IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x=> x.Id);
            List<AuthorsViewModel> returnObj = _mapper.Map<List<AuthorsViewModel>>(authors);

            return returnObj;
        }
    }

    public class AuthorsViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string  dateOfBirth {get; set;}
    }
}
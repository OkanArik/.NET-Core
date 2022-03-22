using AutoMapper;
using Webapi.Applications.AuthorOperations.Commands.CreateAuthor;
using WebApi.Applications.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Applications.BookOperations.Commands.CreateBook;
using WebApi.Applications.BookOperations.Queries.GetBookDetail;
using WebApi.Applications.BookOperations.Queries.GetBooks;
using WebApi.Applications.GenreOperations.Queries.GetAuthorDetail;
using WebApi.Applications.GenreOperations.Queries.GetAuthors;
using WebApi.Applications.GenreOperations.Queries.GetGenreDetail;
using WebApi.Applications.GenreOperations.Queries.GetGenres.GetGenresQuery;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile //MappingProfile sınıfının AutoMapper tarafından bir config sınıfı olarak görülmesi için AutoMapper namespace'i altından gelen Profile sınıfından kalıtım aldırdık.
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();//CreateMap<SourceModel,TargetModel>() ==>Burada CreateBookModel objesini Book Objesine maplenebilir yaptık.
            CreateMap<Book,BookDetailViewModel>()
                                                .ForMember(destination=> destination.Genre,option=>option.MapFrom(source=> source.Genre.Name))
                                                .ForMember(destination=> destination.AuthorNameSurname,option=>option.MapFrom(source=> source.Author.Name +" "+source.Author.SurName));


            CreateMap<Book,BooksViewModel>()
                                           .ForMember(destination=> destination.Genre,option=>option.MapFrom(source=>  source.Genre.Name))
                                           .ForMember(destination=> destination.AuthorNameSurname,option=>option.MapFrom(source=> source.Author.Name +" "+source.Author.SurName));


            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();

            CreateMap<Author,AuthorsViewModel>();
            CreateMap<Author,AuthorDetailViewModel>();
            CreateMap<CreateAuthorModel,Author>();
        }
    }
}
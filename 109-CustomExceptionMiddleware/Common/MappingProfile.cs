using AutoMapper;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;

namespace WebApi.Common
{
    public class MappingProfile : Profile //MappingProfile sınıfının AutoMapper tarafından bir config sınıfı olarak görülmesi için AutoMapper namespace'i altından gelen Profile sınıfından kalıtım aldırdık.
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();//CreateMap<SourceModel,TargetModel>() ==>Burada CreateBookModel objesini Book Objesine maplenebilir yaptık.
            CreateMap<Book,BookDetailViewModel>().ForMember(destination=> destination.Genre,option=>option.MapFrom(source=> ((GenreEnum)source.GenreId).ToString()));//Burada Book objesini BookDetailViewModel objesine maplenebilir yaptık.ForMember  ile de ihtiyaç duyduğum bazı satırları nasıl mapleyeceğini söyledim.
            CreateMap<Book,BooksViewModel>().ForMember(destination=> destination.Genre,option=>option.MapFrom(source=> ((GenreEnum)source.GenreId).ToString()));
        }
    }
}
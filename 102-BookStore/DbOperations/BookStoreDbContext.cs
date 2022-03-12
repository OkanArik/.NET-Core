using Microsoft.EntityFrameworkCore;

namespace WebApi.DbOperations
{
    public class BookStoreDbContext : DbContext//Bu sınıfın bir context sınıfı olması için DbContext sınıfından türemiş olması gerekmektedir.DbContext sınıfı Microsoft.EntityFrameworkCore namespace'i altından gelmektedir.
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options ) : base (options) //Constructor methodunu yarattık.
        { }

        public DbSet<Book> Books {get;set;}//Bu context(database)'e Book entity'isini ekledik ve Books ismile bu entity'nin herşeyine erişebiliriz.Burada bir standart isimlendirme vardır , entity'ler tekil isimlendirilir fakat db de yaratılacak isimler çoğul olur.

        
    }
}
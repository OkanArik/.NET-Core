using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]//Controller 'ımın bir http response döneceğini bu attribute ile taahhüt ettim.
    [Route("[Controller]s")]//GElen request'i hangi resourc'ın karşılayacağını belirlerleyen route attribute'ımı ekledim.
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;//readonly değişkenler uygulama içerisinden değiştirilemezler sadece constructor içerisinden set edilebilirler.

        public BookController(BookStoreDbContext context)
        {
            _context=context;
        }

        // Action Methodlarımı yaratcam yani Http request lerimi karşılacak methodlarımı yaratcam.
        
        [HttpGet]
        public List<Book> GetBooks()//Tüm kitaplarımı sıralı şekilde get(read) ettiğim action methodum.
        {
            var bookList = _context.Books.OrderBy(x=> x.Id).ToList<Book>();
            return bookList;
        }
        

        
        [HttpGet("{id}")]
        public Book GetById([FromRoute] int id)//Route'tan aldığım id değerindeki kitabımı get ettiğim action method'um.
        {
            var book= _context.Books.Where(x=> x.Id==id).SingleOrDefault();
            return book;
        }

        // [HttpGet]        
        // public Book Get([FromQuery] string id)
        // {
        //     var book= _context.Books.Where(x=> x.Id==Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }
        
        //*****Bir id ile resource getirmek istediğimizde doğru olan yaklaşım route'dan almaktır.******
        


        //Post : Post action methodumuzda static book listemize kitap eklicez.
        [HttpPost] //Http verb attribute'ım
        public IActionResult AddBook([FromBody] Book newBook)//Burada IactionResult geri dönüş tipini kullanmamın sebebi validasyonuma göre ya BadRequest() yada Ok() dönüşü yapcam. 
        {
            var book=_context.Books.SingleOrDefault(x=> x.Title == newBook.Title);//Burada book adında generic bir variable tanımladım ve post etmek istediğim kitabın title'ı ile aynı title sahip mevcutda kitab var onu book variable ıma assign ettim.Bunu yapmamın sebebi insert etmek istediğim veri halihazırda varsa benim mevcut verilerimin içerisinde bunu insert etmicem yani bir validasyon yapcam.
            if(book is not null)
               return BadRequest();
            
            _context.Books.Add(newBook);
            _context.SaveChanges();//Bu komut satırını database de her değişiklik yaptıktan sonra yazmalıyız yapmazsak databasedeki değişiklikler kaydedilmez ve değişiklikleri göremeyiz.
            return Ok();
        }

        //Put : Put action methodumuzda mevcut bir kitabımızdaki bilgileri güncellicez.

        [HttpPut("{id}")]//Http verb attribute'ım
        public IActionResult UpdateBook([FromBody] Book updatedBook, int id)//Bu action methodda FromBody'den güncellenecek verilerimi aldım ve route dan da güncellemek istediğim kitabımın id sini aldım.Route'dan aldığım id verisine action methodumda bir validasyon işlemi uygulayacağım eğer güncelleme yapmak istediğim kitap mevcut verilerimde yoksa BadRequest() döncem varsa güncellemeyi yapcam ve Ok() döncem.
        {
            var book=_context.Books.SingleOrDefault(x=> x.Id==id);//Burada book adında generic tipinde bir variable tanımladım ve Linq komutalrı vasıtasıyla routeden aldığım id deki kitap verilerimin içerisinde var ise book variable ıma assign ettim.
            if(book is null)
              return  BadRequest();
            
            book.GenreId = updatedBook.GenreId!=default? updatedBook.GenreId: book.GenreId;//updatedBook ımın GenreId si default değil ise yani güncelleme yapılmak isteniyorsa updatedBook ımla gelen GenreId ile güncelleme işlemi yapılcak ve updatedBook ile gelen GenreId default ise yani güncelleme yapılması istenmiyors güncelleme yapılmıcak.
            book.PageCount=updatedBook.PageCount!=default?updatedBook.PageCount:book.PageCount;
            book.PublishDate=updatedBook.PublishDate!=default?updatedBook.PublishDate:book.PublishDate; 
            book.Title=updatedBook.Title!= default ? updatedBook.Title:book.Title;
            _context.SaveChanges();
            return Ok();
        }

        //Delete :  Delete action methodumuzla mevcut bir resource ımızı nasıl sileriz onu yapcaz.

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book=_context.Books.SingleOrDefault(x=> x.Id==id);

            if(book is null)
              return BadRequest();
            
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
        
    }
}
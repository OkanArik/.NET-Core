using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]//Controller 'ımın bir http response döneceğini bu attribute ile taahhüt ettim.
    [Route("[Controller]s")]//GElen request'i hangi resourc'ın karşılayacağını belirlerleyen route attribute'ımı ekledim.
    public class BookController : ControllerBase
    {
        //External veya inmemory bir database'imiz şu an için olmadığından static bir book listesi tanımlayacaz ve bu kitap listesinin initial değerleri olacak ve static olarak tanımladığımız için uygulama çalıştıkça erişebileceğiz.

        private static List<Book> BookList= new List<Book>()
        {
            new Book{
                Id=1,
                Title="Lean Startup",
                GenreId=1,//Personal Growth
                PageCount=200,
                PublishDate=new DateTime(2001,06,12) 
            },
            new Book{
                Id=2,
                Title="Herland",
                GenreId=2,//Science Fiction
                PageCount=250,
                PublishDate=new DateTime(2010,05,23) 
            },
            new Book{
                Id=3,
                Title="Dune",
                GenreId=2,//Science Fiction
                PageCount=540,
                PublishDate=new DateTime(2001,12,21) 
            },
        };

        // Action Methodlarımı yaratcam yani Http request lerimi karşılayacak methodlarımı yaratcam.
        
        [HttpGet]
        public List<Book> GetBooks()//Tüm kitaplarımı sıralı şekilde get(read) ettiğim action methodum.
        {
            var bookList = BookList.OrderBy(x=> x.Id).ToList<Book>();//booklist adında generic bir variable tanımladım ve BookList'imde ki kitapları Linq komutları vasıtasıyla Id ilerine göre increment olacak şekilde sıralayarak Liste halinde bu variable'ıma atadım.
            return bookList;
        }
        

        
        [HttpGet("{id}")]
        public Book GetById([FromRoute] int id)//Route'tan aldığım id değerindeki kitabımı get ettiğim action method'um.
        {
            var book= BookList.Where(x=> x.Id==id).SingleOrDefault();//book adında generic bir variable tanımladım ve Linq vasıtasıyla BookList'imdeki Id ile routedan aldığım id si eşleşen kitabı buldum ve get(read) ettim. Burada SingleOrDefault() Linq namespace'inin bir kütüphansesidir ve burada bu method ile tekbir değer buluncak ve onu get etcez eğer değer bulunamazsada default yani null get etcez.
            return book;
        }

        // [HttpGet]//Bu action methodu kullanmak için iki yukarıdaki action methodumu yorum satırına almalıyız veya o action methodu kullanmak için bu action method'u yorum satırına almalıyız çünkü sadece bir tane parametresiz HttpGet attribute ' ı kullanabiliriz.
        // public Book Get([FromQuery] string id)//Query'den aldığım id değerindeki kitabımı get ettiğim action method'um.
        // {
        //     var book= BookList.Where(x=> x.Id==Convert.ToInt32(id)).SingleOrDefault();//book adında generic bir variable tanımladım ve Linq vasıtasıyla BookList'imdeki Id ile query'den aldığım id si eşleşen kitabı buldum ve get(read) ettim. Burada SingleOrDefault() Linq namespace'inin bir kütüphansesidir ve burada bu method ile tekbir değer buluncak ve onu get etcez eğer değer bulunamazsada default yani null get etcez.
        //     return book;
        // }
        
        //*****Bir id ile resource getirmek istediğimizde doğru olan yaklaşım route'dan almaktır.******
        


        //Post : Post action methodumuzda static book listemize kitap eklicez.
        [HttpPost] //Http verb attribute'ım
        public IActionResult AddBook([FromBody] Book newBook)//Burada IactionResult geri dönüş tipini kullanmamın sebebi validasyonuma göre ya BadRequest() yada Ok() dönüşü yapcam. 
        {
            var book=BookList.SingleOrDefault(x=> x.Title == newBook.Title);//Burada book adında generic bir variable tanımladım ve post etmek istediğim kitabın title'ı ile aynı title sahip mevcutda kitab var onu book variable ıma assign ettim.Bunu yapmamın sebebi insert etmek istediğim veri halihazırda varsa benim mevcut verilerimin içerisinde bunu insert etmicem yani bir validasyon yapcam.
            if(book is not null)
               return BadRequest();
            
            BookList.Add(newBook);
            return Ok();
        }

        //Put : Put action methodumuzda mevcut bir kitabımızdaki bilgileri güncellicez.

        [HttpPut("{id}")]//Http verb attribute'ım
        public IActionResult UpdateBook([FromBody] Book updatedBook, int id)//Bu action methodda FromBody'den güncellenecek verilerimi aldım ve route dan da güncellemek istediğim kitabımın id sini aldım.Route'dan aldığım id verisine action methodumda bir validasyon işlemi uygulayacağım eğer güncelleme yapmak istediğim kitap mevcut verilerimde yoksa BadRequest() döncem varsa güncellemeyi yapcam ve Ok() döncem.
        {
            var book=BookList.SingleOrDefault(x=> x.Id==id);//Burada book adında generic tipinde bir variable tanımladım ve Linq komutalrı vasıtasıyla routeden aldığım id deki kitap verilerimin içerisinde var ise book variable ıma assign ettim.
            if(book is null)
              return  BadRequest();
            
            book.GenreId = updatedBook.GenreId!=default? updatedBook.GenreId: book.GenreId;//updatedBook ımın GenreId si default değil ise yani güncelleme yapılmak isteniyorsa updatedBook ımla gelen GenreId ile güncelleme işlemi yapılcak ve updatedBook ile gelen GenreId default ise yani güncelleme yapılması istenmiyors güncelleme yapılmıcak.
            book.PageCount=updatedBook.PageCount!=default?updatedBook.PageCount:book.PageCount;
            book.PublishDate=updatedBook.PublishDate!=default?updatedBook.PublishDate:book.PublishDate; 
            book.Title=updatedBook.Title!= default ? updatedBook.Title:book.Title;
            return Ok();
        }

        //Delete :  Delete action methodumuzla mevcut bir resource ımızı nasıl sileriz onu yapcaz.

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book=BookList.SingleOrDefault(x=> x.Id==id);

            if(book is null)
              return BadRequest();
            
            BookList.Remove(book);
            return Ok();
        }
        
    }
}

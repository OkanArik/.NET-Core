using System;
using System.Linq;
using LinqıleCrudIslemler;
using LinqIleCrudIslemler.DbOperations;

namespace LinqIleCrudIslemler
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context=new LinqDbContext();
            var students=_context.Students.ToList<Student>();
            foreach (var item in students)
            {
                Console.WriteLine("StudentId : "+item.StudentId);
                Console.WriteLine("Name : "+item.Name);
                Console.WriteLine("Surname : "+item.Surname)    ;
                Console.WriteLine("ClassId : "+item.ClassId);
            }

            //Find():DBSet sınıfı ile kullanılabilen bir metottur. İlgili DbSet üzerinden Primary Key olarak tanımlanan alana göre arama yapmak için kullanılır.
            Console.WriteLine();
            Console.WriteLine("*****Find()*****");
            var student=_context.Students.Where(x=> x.StudentId==1).FirstOrDefault();//Burada db deki 1 numarayı StudentId PK ya eşit veriyi generic student variable değişkenine atadık.
            Console.WriteLine("StudentId : "+student.StudentId);
            Console.WriteLine("Name : "+student.Name);
            Console.WriteLine("Surname : "+student.Surname);
            Console.WriteLine("ClassId : "+student.ClassId);

            Console.WriteLine("*************************");
            student= _context.Students.Find(1);//Linq namespace'i altından gelen Find() methodunu kullanarak  PK olan StudentId si 1 e eşit verileri generic student1 variable'ına assign ettim.
            Console.WriteLine("StudentId : "+student.StudentId);
            Console.WriteLine("Name : "+student.Name);
            Console.WriteLine("Surname : "+student.Surname);
            Console.WriteLine("ClassId : "+student.ClassId);
            

            //First/FirstOrDefault():First ve FirstOrDefault birden fazla verinin olabileceği sorgulamaların sonunda listedeki ilk elemanı seçmek için kullanılır.7
            //Önemli: First() ve FirstOrDefault() arasındaki temel fark; eğer listede veri bulunamazsa First() hata fırlatırken, FirstOrDefault() geriye null döndürür. Bu nedenle FirstOrDefault() ile veriyi çekip daha sonradan verinin null olup olmadığını kontrol etmek daha doğru bir yaklaşım olur.
           
            Console.WriteLine();
            Console.WriteLine("*****First/FirstOrDefault()*****");
            student=_context.Students.Where(x=> x.Surname=="Arda").FirstOrDefault();//Db de iki tane surname'i Arda olan veri var burada bize ilk bulduğu veriyi getirir ve uygu ver olmasaydı Db de o zaman null yani default dönerdi.
            Console.WriteLine("StudentId : "+student.StudentId);
            Console.WriteLine("Name : "+student.Name);
            Console.WriteLine("Surname : "+student.Surname);
            Console.WriteLine("ClassId : "+student.ClassId);
            Console.WriteLine("*************************");
            
            student= _context.Students.FirstOrDefault(x=> x.Surname=="Arda");// Bu yazım şekli ileki bir yukarıdaki yazım şekli aynı sonucu getirir.
            Console.WriteLine("StudentId : "+student.StudentId);
            Console.WriteLine("Name : "+student.Name);
            Console.WriteLine("Surname : "+student.Surname);
            Console.WriteLine("ClassId : "+student.ClassId);

            
            //SingleOrDefault():Sorgulama sonunda kalan tek veriyi geri döndürür. Eğer listede birden fazla eleman varsa hata döndürür. Listede hiç eleman yoksa geriye null döndürür.
            Console.WriteLine();
            Console.WriteLine("*****SingleOrDefault()*****");
            student = _context.Students.SingleOrDefault(x=> x.Name=="Deniz");// Burada SingOrDefault methodunun içerisine yazdığım şarttan birden fazla veri dönmeyeceğine emin olunması gerekmektedir.Çünkü bu methodun kullanıldığı durumda birden fazla veri dönerse hata fırlatır.
            Console.WriteLine("StudentId : "+student.StudentId);
            Console.WriteLine("Name : "+student.Name);
            Console.WriteLine("Surname : "+student.Surname);
            Console.WriteLine("ClassId : "+student.ClassId);

            //ToList():Sorgulama sonucunu geriye koleksiyon olarak döndürmek için kullanılır.
            Console.WriteLine();
            Console.WriteLine("*****ToList()*****");
            var studentList=_context.Students.Where(x=> x.ClassId==2).ToList();
            foreach(var item in studentList)
            {
                Console.WriteLine("StudentId : "+item.StudentId);
                Console.WriteLine("Name : "+item.Name);
                Console.WriteLine("Surname : "+item.Surname)    ;
                Console.WriteLine("ClassId : "+item.ClassId);
            }
            Console.WriteLine();
            Console.WriteLine(studentList.Count);
            

            //OrderBy()/OrderByDescending():OrderBy() bir listeyi sıralamak için kullanılır. OrderBy() varsayılan olarak Ascending sıralama sunar. Tersi sıralamak için OrderByDescending() kullanılmalıdır.
            Console.WriteLine();
            Console.WriteLine("*****OrderBy*****");
            Console.WriteLine();
            var studentListSort=_context.Students.OrderBy(x=> x.StudentId).ToList();
            foreach (var item in studentListSort)
            {
                Console.WriteLine("StudentId : "+item.StudentId);
                Console.WriteLine("Name : "+item.Name);
                Console.WriteLine("Surname : "+item.Surname)    ;
                Console.WriteLine("ClassId : "+item.ClassId+"\n");
            }
            Console.WriteLine("*****OrderByDescending()*****");
            Console.WriteLine();
            studentListSort=_context.Students.OrderByDescending(x=> x.StudentId).ToList();
            foreach (var item in studentListSort)
            {
                Console.WriteLine("StudentId : "+item.StudentId);
                Console.WriteLine("Name : "+item.Name);
                Console.WriteLine("Surname : "+item.Surname)    ;
                Console.WriteLine("ClassId : "+item.ClassId+"\n");
            }
            
            //Anonymous Object Result:LINQ her zaman geriye entity objesi dönmek zorunda değildir. Query sonucunu kendi yarattığınız bir obje formatında döndürebilirsiniz.
            Console.WriteLine("*****Anonymous Object Result*****");
            Console.WriteLine();
            var anonymousObject=_context.Students.Where(x=> x.ClassId==2)
                                                 .Select
                                                 (x=> new {
                                                           Id=x.StudentId,
                                                           FullName=x.Name+" "+x.Surname
                                                 });

             foreach (var obj in anonymousObject)
            {
                Console.WriteLine("Id - FullName : "+obj.Id+" - "+obj.FullName);
            }
            
        }
    }
}

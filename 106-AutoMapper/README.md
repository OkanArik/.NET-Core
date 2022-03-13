# Proje Refactor Edilerek AutoMapper Uygulandı

---

# AutoMapper
- `Automapper farklı tipteki complex objeleri birbirlerine otomatik olarak dönüştüren kütüphanedir. Kod kirliliğinde bizi kurtarak birden fazla satırda her bir obje elemanını tek tek dönüştürmek yerine tek satırda objenin kendisini dönüştürmemize olanak sağlar.`


Bir .Net 5 yada .Net Core Projesine Auto Mapper implemente etmek için izlenmesi gereken adımlar aşağıdaki gibidir.


1.Öncelikle Automapper kütüphanesinin projeye dahil edilmesi gerekir.

- AutoMapper paketi için aşağıdaki kod satırının .csproj dosyasının olduğu dizinde çalıştırılması gerekir.
- `dotnet add package AutoMapper --version 10.1.1`
- AutoMapper Dependecy Injection Paketi için aşağıdaki kod satırının .csproj dosyasının olduğu dizinde çalıştırılması gerekir.
- `dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 8.1.1`

2. Proje içerisinde AutoMappper'ı servis olarak kullanabilmemiz için Startup.cs dosyası içerisindeki Configure Service metoduna aşağıdaki kod satırının eklenmesi gerekir.
- `services.AddAutoMapper(Assembly.GetExecutingAssembly());`

3.Mapper Konfigürasyonu için Profile sınıfından kalıtım alan aşağıdaki gibi bir sınıf implemente etmemiz gerekir.

![Ekran görüntüsü 2022-03-13 220727](https://user-images.githubusercontent.com/89224500/158075006-174a933d-1969-41a8-9191-cd1fbf519519.png)

4.Eklemiş olduğumuz Dependency Injection paketi sayesinde Controller'ın kurucu fonksiyonunda mapper'ı kod içerisinde kullanılmak üzere dahil edebiliriz.

![Ekran görüntüsü 2022-03-13 220802](https://user-images.githubusercontent.com/89224500/158075020-ec7b8bb5-f861-4d78-95aa-2cd07606c9ae.png)

5.Artık kod içerisinde _mapper'ı kullanabiliriz.
- Profile sınıfından kalıtım alan sınıfa (Yukarıdaki örnekte MappingProfile) daha yakından bakmakta fayda var. Çünkü mapping konfigurasyonlarımız o sınıftan geliyor.
- CreateMap<Source,Target> parametreleri ile çalışır. Bu şu demek; kod içerisinde source ile belirtilen obje tipi target ile belirtilen obje tipine dönüştürülebilir.
- `CreateMap<CreateBookModel, Book>();`
- Objeyi olduğu gibi çevirmek istiyorsak yani her tipteki obje field ları birbiri ile aynı olduğu durumda yukarıdaki tanımlama yeterlidir.

Mapper ile obje özelliklerinin birbirine nasıl map'laneceğini de söyleyebiliriz.

![Ekran görüntüsü 2022-03-13 221035](https://user-images.githubusercontent.com/89224500/158075093-cc8587d4-5fac-4d60-884e-b8019d68d3ff.png)
- Yukarıdaki örneği incleyelim. Öncelikle Book tipindeki bir objenin BookDetailViewModel tipindeki bir objeye dönüştürülebildiğini görürüz. Ve ForMember() kullanımı da şunu söylüyor.

BookDetailViewModel içerisindeki Genre özel bir şekilde oluşuyor. Source olan Book objesi içerisindeki GenreId'nin GenreEnum'daki string karşılığıdır. Eğer book objesi içerisine bakarsak Genre diye bir özellik göremeyiz. Ama BookDetailView modeline mapleme yaptığımızda Genre özelliğini görebiliriz.

Bu ForMember() kullanımı ile istediğimiz kadar özelleştirme yapabiliriz.










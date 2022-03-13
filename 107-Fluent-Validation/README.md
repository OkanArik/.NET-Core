# Proje Refoctor Edlidi Ve Fluent Validation Uygulanarak Web Api Koruma Altına Alındı

---

# Modellerin Doğrulanması ve FluentValidation Kütüphanesi

- Uygulama geliştirirken en zor noktalardan birisi sistemi kararlı yapıda tutmaktır. Bunu yapmanın yolu da validasyonlardan geçiyor. Peki yazılım geliştirirken validasyon yapmak ne demek? Şöyle düşünün bir post endpoint'iniz var. Input olarak aldığı obje içerisinde de integer bir özellik var. Ve bu özelliğin mantıksal olarak 0 olmaması gerekiyor. Yada boş geçilmemesi gerekiyor. Eğer servisiniz bu özelliği kontrol etmeden db'ye yazarsa, database'in hata fırlatmasına ve uygulamanızın çalışma anında kırılmasına neden olur. Daha da kötüsü kırılmadan devam eder ve data bütünlüğünün bozulmasına neden olabilir.
- Bir validasyon yapısı kurmak hem kuralların okunabilirliği hem de kuralların esnetilebilir olması açısından çok faydalıdır. Bu amaçla yaratılmış bir çok açık kaynaklı kütüphane bulunur. .Net uygulamaları için en çok kullanılan validation kütüphanesi ise FluentValidation dır.
- FluentValidation'ı kullanabilmiz için öncelikle kütüphaneyi paket olarak uygulamamıza eklememiz gerekir.
- `dotnet add package FluentValidation`

Şimdi gelin bir örnek üzerinden nasıl kullanıldığını keşfedelim. Aşağıdaki gibi bir Customer modelimizin olduğunu varsayalım.

![Ekran görüntüsü 2022-03-14 020811](https://user-images.githubusercontent.com/89224500/158083100-37818887-4931-4e76-b9a1-f8bf3c73d0ca.png)

Customer modelinin özelliklerini doğrulamak istersek aşağıdaki gibi bir validasyon sınıfı oluşturmamız gerekir:

![Ekran görüntüsü 2022-03-14 020839](https://user-images.githubusercontent.com/89224500/158083112-768df2d5-561e-43eb-bf68-46109e568422.png)

Şimdi `Customer`'ın özelliklerini bir takım kurallar ile kapsayalım :

![Ekran görüntüsü 2022-03-14 020921](https://user-images.githubusercontent.com/89224500/158083134-a10cb394-6f51-42ff-b0dc-5096277182b5.png)

Yukarıdaki 2 kuralı incelersek;

- Surname null olamaz.
- Discount 0'dan büyük olmak zorundadır.

Peki bu validasyonu nasıl çalıştırıcaz ?

![Ekran görüntüsü 2022-03-14 021044](https://user-images.githubusercontent.com/89224500/158083182-9ee7ed16-b389-4753-9a94-b64bc6743ec8.png)

Validasyon sınıfının bir nesnesi oluşturup Validate() metodunu çağırırsak geriye validasyon sonuçları döner. result objesi içerisinde IsValid özelliği validasyon sonucunda hata olup olmadığını geri döner. Ayrıca result objesi Errorsadında bir de hata mesajlarını barındıran bir dizi bulundurur. foreach döngüsü yardımıyla bu hata mesajlarını istediğimiz gibi kullanabiliriz. Yukarıdaki örnek içerisinden console'a yazdırdık. Burda bir log altyapısı varsa loglama yapılabilir yada son kullanıcıya geri döndürülebilir.

Peki eğer ben bir model validasyondan geçmezse hata fırlatmasını istersem ne yapmalıyım? Bunun için de FluentValidation Kütüphanesi ValidateAndThrow adında bir metot barındırır. Bu metot önce kontrolleri yapar, eğer hata varsa hata mesajlarını fırlatır.

![Ekran görüntüsü 2022-03-14 021141](https://user-images.githubusercontent.com/89224500/158083213-81798b17-e102-4ea5-ae37-d61ef64afaec.png)

Throw edilen bu hata mesajlarını try catch blokları ile yakalayıp istediğimiz gibi yönetebiliriz. Istersek loga yazarız istersek son kullanıcıya hata mesajı olarak dönebiliriz.



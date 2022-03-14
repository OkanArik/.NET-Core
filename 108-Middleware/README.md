# Middleware örneklemesi:
- Middleware dersi tamamlandı ve örnekler uygulandı.Startup.cs ve Middleware klasöründe işlenen konuların örnekleri bulunmaktadır.

--- 
# Middleware Kavramı
- Middleware yani ara katman client tarafından bir request gönderildiğinde request'e karşılık response dönene kadar geçen sürede yapılması gereken işlemler için process'in arasına girmeyi sağlayan yapılardır. Request ve response arasına girip işlem yapmamıza olanak sağlamasının yanında, bu aralığa çoklu işlemler de dahil edebiliriz. Bu işlemlerin hangi sırayla yapılacağını da belirleyebiliriz.
# .Net5'de Middleware Yapısı
- .Net5 içerisindeki middleware'ler Startup sınıfı içerisinden Configure metodu içinde saklanır. Middleware'lerin çalışacağı pipeline ı bu metot içerisinde belirleriz.

Örnek:

![Ekran görüntüsü 2022-03-15 001255](https://user-images.githubusercontent.com/89224500/158261717-f25d7921-c000-457a-a9a6-f6e357df38d8.png)

- Yukarıdaki örnekte app.Use ile başlayan ifadeler .Net'in kendi özel middleware leridir. Örneğin `app.UseHttpsRedirection()` ;bu middleware bir https yönlendirmesi yapar.

## Run Metodu
- Bazı metotlar pipeline içerisinde kısa devreye neden olur. Yani kendisinden sonraki işlemler gerçekleşmez. Bu tip meotları kullanırken dikkatli olmak gerekir. Run bunlardan biridir.
![Ekran görüntüsü 2022-03-15 001413](https://user-images.githubusercontent.com/89224500/158261869-7e9d9b16-88d5-44dc-b85c-4d2d16b347d7.png)
- Örneğin yukarıdaki pipeline'ı bir inceleyelim. Arka arkaya 2 middleware tetikledik. Normal şartlar altında bunu Run ile kullanmamış olsaydık, arkad arkaya aşağıdaki ifadeleri client'a response olarak yazacaktı.
![Ekran görüntüsü 2022-03-15 001446](https://user-images.githubusercontent.com/89224500/158261945-78b59aa7-1ee4-4895-aec2-c34954271eb0.png)
- Ama bu pipelien çalıştığında sadece `Middleware 1.`Çünkü Run() metodu pipeline'ın kısa devre yapmasına neden oldu. 2. middleware çalışamadı.
## Use Metodu
- Devreye girdikten sonra kendinden sonraki middleware'i tetikleyebilir ve işi bittikten sonra kaldığı yerden devam edilebilir bir yapı sunar.
![Ekran görüntüsü 2022-03-15 001600](https://user-images.githubusercontent.com/89224500/158262094-649966e7-aca7-4bb5-9549-af58182f23a0.png)
- Yukarıdaki kod bloğu çalıştığında çıktısı şu şekilde olur:
![Ekran görüntüsü 2022-03-15 001635](https://user-images.githubusercontent.com/89224500/158262165-8e2ba136-d4c6-40cb-a588-7a33b60fdee4.png)
- Görüldüğü üzere Middleware 1 çalıştı. İlk komutu yazdırdıktan sonra sonraki middleware'i çağırdı. Use metodu içerisindeki `await next.Invoke()` ; bir sonraki middleware çğıran komuttur. 2. Middleware'de komutunu yazdırdı. Ama `Run()` metodu ile çağırıldığı için bir kısa devreye neden oldu. Kendisinden sonra bir middleware çağrımı olsaydı çalışmayacaktı. Pipeline sona erdiği için Middleware 1 kaldığı yerden devam etti ve komutunu ekrana yazdırıp sona erdi.
## Map Metodu
- Middleware lerin path bazından çalışmasını istediğimiz durumlarda kullanırız. `Use()` yada `Run()` metodunu `if()` statement ile yöneterekte bunu yapabiliriz. Ama Map metodu bize bunu kolayca yönetme olanağı sağlıyor.
- Örnek: public void Configure(IApplicationBuilder app, IHostingEnvironment env) { app.Use(async (context, next) => { Console.WriteLine("Middleware 1 tetiklendi."); await next.Invoke(); });
![Ekran görüntüsü 2022-03-15 001908](https://user-images.githubusercontent.com/89224500/158262507-d7d103ee-c96a-4d09-89ed-b81f0277ada3.png)
- Yukarıdaki kod bloğu çalıştığında eğer `/test` path'ine bir istek gelirse console çıktısı aşağıdaki gibi olur.
![Ekran görüntüsü 2022-03-15 002029](https://user-images.githubusercontent.com/89224500/158262760-84f8a64c-2a40-4e87-8ccd-8613f32a7724.png)
- Path `/test` değil ise çıktı aşağıdaki gibi olacaktır.
![Ekran görüntüsü 2022-03-15 002231](https://user-images.githubusercontent.com/89224500/158263035-d0ae1f64-caae-4478-a09d-51592aa6ffa7.png)

## MapWhen Metodu
- Map metodu ile sadece path'e bazında middleware yönetebilirken MapWhen ile request'e bağlı olarak her türlü yönlendirmeyi yapabiliriz.

Örnek:
![Ekran görüntüsü 2022-03-15 002326](https://user-images.githubusercontent.com/89224500/158263187-e1d04778-44ba-4d44-8764-92a178bc8bc0.png)
- Yukarıdaki örneği inceleyecek olursak, tipi HttpGet olan requestlere özel çalışacak bir middleware yaratılmış olduğunu görürüz.

---
#`Custom Extension Middleware Yaratmak`
- Middleware lerimizi Use, Run, Map ve MapWhen gibi metotlarla tanımlayabileceğimiz için bize özel extension şeklinde de yazabiliriz.

Örnek:

![Ekran görüntüsü 2022-03-15 002457](https://user-images.githubusercontent.com/89224500/158263413-af29e756-18fe-4a8e-bce6-b5c76980b796.png)

Yukarıdaki örneği inceleyecek olursak öncelike bir HelloMiddleware sınıfının oluşturulduğunu ve ona ait bir `Invoke()` metodunun yazıldığını görüyoruz `await _next.Invoke(context);` komut satırı ile de bir sonraki middleware çağırılıyor.

Son olarakta ekrana `Bye World!` yazması bekleniyor.



Son olarak `HelloMiddlewareExtension` static sınıfı içerisindeki `UseHelloWorld` extension metodu içerisindeki `UseMiddleware<HelloMiddleware>()` metot çağrımı middleware ı ekler.



Kesin bir kural olmamakla birlikte middleware ler standart olarak Use prefix'i ile başlar.





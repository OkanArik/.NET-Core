### Projemi dependency injection konusunu uygularak refactor ettim . Services klasörünün altına ILoggerServices interface ini, ve ConsoleLogger class'ı ile DBLogger class'ını yarattım Dı yımı startup dosyamda configureServices methoduna tanıttım ve projemdeki loglama işlemlerimde bağımlıkran kurtularak DI sayesinde daha değişime kapalı ve daha gelişime açık kod haline getirdim.Bana sağladığı önemli yarardan biriside şu ki Startup dosyamda tanıtmış olduğum DI ımda ufak bir değişiklikle loglamaya iste DB ye ister Console yapabilir hale geldim.

---

# Dependency Nedir ?

Nesne yönelimli programlama dilleri ile uygulama geliştirirken, kullandığımız nesneler arasında bir iletişim kurarız. Bu iletişimin bir sonucu olarak da nesneler arasında bir bağımlılık (dependency) oluşmuş olur.


Aşağıda bir örneğini gördüğümüz gibi, Foo sınıfı içerisinde Bar isimli sınıfa ait bir methodu kullanmakta. Bu durumda Foo sınıfı, Bar sınıfına direkt olarak bağımlıdır.

![Ekran görüntüsü 2022-03-16 002959](https://user-images.githubusercontent.com/89224500/158475388-e16c0944-d2b1-425e-b5fc-ba6aa65416d4.png)


Bu örnekte olduğu gibi, bağımlı olunan nesneler sınıf içerisinde `new` ile oluşturulup bir üyesi çağrıldığında, bu sınıfa bağımlı hale gelmiş olurlar.

Bağımlı olunan nesneler yalnızca kendi yazdığımız sınıflar arasında değil, kullandığımız tüm framework yada kütüphaneler tarafından sağlanan sınıflar/tipler için de geçerlidir. Bu durumlarda da ilgili framework yada kütüphaneye bağımlı bir kod geliştirmiş oluruz.

Bağımlı olunan nesneleri yalnızca new ile üretilen nesneler olarak düşünmememiz gerekir. Kullandığımız static methodlar da aslında dolaylı olarak bir bağımlılık yaratmaktadır. Bağımlılıkları incelerken kullanılan nesnelere ek olarak varsa statik methodları da incelememiz ve değerlendirmemiz gerekir. Örnek olarak `DateTime.Now` kullanarak bir kontrol yaptığımızda aslında ilgili kod DateTime.Now değerine bağımlı hale gelmiş olur. Bu bağımlılıktan kurtulmak için kontrol yapacağımız DateTime değerini sınıfın yada methodun dışında parametre aracılığı ile almamız gerekir.

Bu şekilde bağımlı sınıflara sahip olmamız, uygulamamız büyüdükçe bağımlılıkları yönetmemizi zorlaştırır ve daha fazla hataya açık bir hale gelmesine yol açar.

Bu bağımlılıkları Dependency Injection (bağımlılıkların dışarıdan verilmesi) tekniği uygulayarak yönetebilir, yazdığımız sınıfları daha az bağımlı hale getirebiliriz. Yazdığımız sınıfların birbirinden daha az bağımlı olması uygulamamızın daha esnek ve genişletilebilir olmasını sağlamakla beraber aynı zamanda otomatize testler yazmamızı da kolaylaştırır.

---
# Dependency Injection (DI) Kavramı (Bağımlılıkların Dışarıdan Verilmesi)

Dependency Injection tekniği uygulayarak bağımlılıkları sınıf içerisinde yönetmek yerine dışarıdan verilmesini sağlarız. Bu sayede bağımlı olunan nesnenin oluşturulması ve yönetimi sınıf dışında yapılmış olur ve bağımlılığın bir kısmı azaltılmış olur.

Aşağıdaki örneği inceleyecek olursak, Foo sınıfı Bar sınıfına bağımlı durumda. Fakat Bar sınıfına ait bir nesneyi yapıcı methodunda parametre olarak dışarıdan verilmesini bekliyor. Bu durumda artık Foo sınıfından bir nesne üretmek istediğimizde aynı zamanda bir de Bar sınıfından nesne üretmeli ve Foo sınıfının yapıcı methoduna vermeliyiz. Bu şekilde Foo sınıfından bir nesne ürettiğimizde aslında Foo sınıfının bağımlı olduğu Bar nesnesini dışarıdan vermiş yani Dependency Injection tekniğini uygulamış olduk.

![Ekran görüntüsü 2022-03-16 003452](https://user-images.githubusercontent.com/89224500/158476076-4311a5c1-720c-4247-9e00-1f4c537b95c7.png)

- Dependency Injection tekniğini 3 farklı yöntem ile uygulayabiliriz.

1 - Constructor (Yapıcı Method) ile : Bu yöntemde bağımlı olunan nesneler yapıcı methodda belirtilir ve dışarıdan beklenir. Yukarıdaki örnek bu yönteme bir örnektir. Foo sınıfı Bar nesnesini yapıcı methodda bekler. Bu yöntem en sık kullanılan yöntemdir.

2 - Setter Method/Property ile : Bu yöntemde bağımlı olunan nesneler bir method/property aracılığı ile dışardan beklenir.Örnek olarak Foo sınıfımız aşağıdaki şekilde bir Setter method ile bağımlı olduğu Bar nesnesini dışarıdan almış olur.

![Ekran görüntüsü 2022-03-16 003557](https://user-images.githubusercontent.com/89224500/158476229-0607abdf-d04e-4c5f-ab5c-dfac9b90565c.png)

3 - Metot ile : Bu yöntemde bağımlı olunan nesneler yalnızca kullanıldığı methodlarda dışarıdan beklenir. Örnek olarak Foo sınıfı DoSomething metodu içerisinde bağımlı olduğu Bar sınıfına ait bir nesneyi metot parametresi aracılığı ile dışardan almış olur.

![Ekran görüntüsü 2022-03-16 003630](https://user-images.githubusercontent.com/89224500/158476295-6971d2ad-ffa7-416a-b46f-005222d189ef.png)

---
# DI Container Kavramı

Uygulamamız büyüdükçe/değiştikçe ekleyeceğimiz bir çok yeni sınıf beraberinde yeni bağımlılıkları da getirecektir. Bu da bağımlılıkların yönetiminin zorlaşmasına ve hatta içinden çıkılmaz bir hal almasına sebep olabilir.

Bağımlılık yönetimini kolaylaştırmak için Dependency Injection Container adı verilen kütüphaneler kullanılır. Bu kütüphanelerin yardımı ile ihtiyacımız olan sınıfa ait bir nesneye; bağımlılıkları dışarıdan verilmiş kullanıma hazır bir şekilde rahatlıkla ulaşarak kullanabiliriz. Böylece ihtiyacımız olan bir nesneyi oluştururken bağımlı olduğu nesnelerin de yaratılması işlemlerinden kurtulmuş oluruz.

Container'a uygulamamız içerisindeki hangi sınıfları container aracılığı ile kullanacağımız ile ilgili bilgi veririz. Burada hem kullanacağımız sınıfları hem de bunların bağımlı olduğu diğer sınıfları containera kaydetmiş olmamız gerekir. Container tüm bu sınıfları bildiği için kayıtlı olan bir sınıfa ait bir nesne üretmesi gerektiğinde bağımlılıkları da otomatik olarak çözerek bize ihtiyacımız olan nesneyi oluşturur.

Aşağıdaki örnekte görebileceğimiz gibi hem Foo hem Bar sınıfımız önce container'a kayıt ediliyor. Daha sonra bir Foo nesnesini container'dan istediğimizde container; Foo sınıfının Bar sınıfına olan bağımlılığını görüyor ve önce Bar nesnesini üretip daha sonra Foo nesnesinin yapıcı methoduna bu nesneyi vererek (injection) bize bir Foo nesnesi üretmiş oluyor.

![Ekran görüntüsü 2022-03-16 004028](https://user-images.githubusercontent.com/89224500/158476793-83df3727-3e38-4890-8a30-585c46ef8855.png)

Not: Yukarıdaki örnekte kullanılan DIContainer sınıfı ve metotları anlaşılabilir kılınmak adına isimlendirilmiştir. Kullanılan kütüphaneye göre gerçek method ve sınıf isimleri değişecektir.

Containerların önemini anlamak için örneğimizi biraz daha genişletelim. Bar sınıfının da yeni eklenen Baz sınıfına bağımlı hale geldiğini düşünelim. Son durumda sınıflar aşağıdaki şekilde olacaktır.

![Ekran görüntüsü 2022-03-16 004134](https://user-images.githubusercontent.com/89224500/158476942-bbf7b8ec-6060-4507-a197-9e092b729935.png)

Eğer ki bağımlılıkları container kullanmadan kendimiz yönetiyor olsaydık tüm uygulamamız içerisinde aşağıdaki şekilde Bar sınıfının bağımlılığını karşılamak için Baz nesnesi yaratmamız gerecekti. Uygulamamız ne kadar büyük ve Bar kullanıyorsa değişiklik yapacağımız yerler de o kadar çok olacak ve efor harcayacaktık.

![Ekran görüntüsü 2022-03-16 004205](https://user-images.githubusercontent.com/89224500/158477001-bd1c73ef-a2f5-42f8-894d-7ede341145af.png)

Fakat container kullandığımız durumda bu değişikliklerin hiçbirini yapmadan, sadece yeni eklediğimiz Baz sınıfını containera kaydetmemiz yeterli olacak. Çünkü container Bar'ın Baz bağımlılığını biliyor ve Baz sınıfı için de bilgisi var. Bu nedenle uygulamamızın hiç bir yerinde başka bir değişiklik yapmamıza gerek yok. Container bizim için bunları yerine getiriyor.

![Ekran görüntüsü 2022-03-16 004252](https://user-images.githubusercontent.com/89224500/158477117-b1de7907-4db3-4b21-97ab-087e2ef2a5b0.png)

Dependency Injection Container'lardan kısaca DI Container olarak bahsedilir. Aynı zamanda DI Framework, IoC Container yada IoC Framework olarak da kullanımlarına rastlanabilinir.



.Net Core uygulamalarında kullanılabilecek bir çok farklı DI Container kütüphanesi mevcuttur. Çoğu temelde aynı işlevi sunar, fakat performans ve bazı ek yetenekler nedeniyle ihtiyaca göre bir seçim yapılabilir.




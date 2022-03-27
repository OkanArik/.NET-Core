## Örneklemesi yapılan konuların konu anlatımları
---
### Bir Projeye Entity Framework Core Nasıl Eklenir?
- Bir .Net Core WebApi projesinde Ef Core kullanabilmek için öncelikle gerekli paketleri projeye dahil etmeliyiz.Dotnet'in paket yöneticisi Nuget Package Manager'dır.Localde çalışma yaparken gerçek bir veri tabanı ile çalışmak maliyetli olabilir. Bunun yerine hem implementasyonu kolay olan hem de hızlı çalışan InMemory database kullanılması önerilir. Ef Core'un tüm özelliklerini in memory database implemente ederek kullanabiliriz. BookStore uygulamamıza da In Memory database implemente ederek EF Core u kullanıcaz.

Projeyi In Memoery EF Core ile çalışır hale getirmek için izlememiz gereken adımlar şu şekildedir arkadaşlar.

#### 1.Projeye Microsoft.EntityFrameworkCore'nin eklenmesi
- WebApi proje dizininde aşağıdaki komutu çalıştırınız.
- `dotnet add package Microsoft.EntityFrameworkCore --version 5.0.6`
#### 2.Projeye Microsoft.EntityFrameworkCore.InMemory'nin eklenmesi.
- WebApi proje dizininde aşağıdaki komutu çalıştırınız.
- `dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 5.0.6`
#### 3.Db operasyonları için kullanılacak olan DB Context'i yaratılması
![Ekran görüntüsü 2022-03-12 175834](https://user-images.githubusercontent.com/89224500/158022925-3af8c2e8-7488-4c99-bb48-00ce5c456591.png)
#### 4.Initial Data için bir Data Generator'ın yazılması
![Ekran görüntüsü 2022-03-12 175935](https://user-images.githubusercontent.com/89224500/158022983-5a851a37-bcf5-4792-a871-3c01bbec2e58.png)
#### 5.Uygulama ayağa kalktığından initial datanın in memory DB'ye yazılması için Program.cs içerisinde configurasyon yapılması
![Ekran görüntüsü 2022-03-12 180042](https://user-images.githubusercontent.com/89224500/158023026-ce838813-b69e-4cd1-b618-4a1f50281410.png)
#### 6.Startup.cs içerisinde ConfigureServices() içerisinde DbContext'in servis olarak eklenmesi
![Ekran görüntüsü 2022-03-12 180125](https://user-images.githubusercontent.com/89224500/158023051-69e31414-4e78-4fc3-8d5f-bd2d8fbc53d7.png)
#### 7.Kullanmak istediğiniz yerde _context'i kurucu metot aracılığıyla ekleyerek kullabilirsiniz.
![Ekran görüntüsü 2022-03-12 180231](https://user-images.githubusercontent.com/89224500/158023094-e6422a98-4dcd-470b-b391-1d2892f913f9.png)
---

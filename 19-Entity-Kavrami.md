# Entity Kavramı
- `Entity Framework içindeki bir entity esasında veritabanı tablosuyla eşleşen bir sınıftır. Bu sınıf, DbContext sınıfına DbSet <TEntity> türü özelliği olarak dahil edilmelidir.EF her entity sınıfını bir tabloya ve bir entity sınıfın her özelliğini veritabanındaki bir tablo kolonuna eşler.`

Örneğin, aşağıdaki `Student` ve `Grade`, `School` uygulamasındaki entity sınıflarıdır.Örnek olarak aşağıdaki Student ve Grade sınıflarını düşünelim.

![Ekran görüntüsü 2022-03-12 215229](https://user-images.githubusercontent.com/89224500/158030917-2efbac66-5bdf-4e5b-b521-7c909fc46954.png)
- `SchoolDBContext` adında da bir context'imiz olduğunu düşünelim. `Student` ve `Grade` sınıflarımızı `DbSet<TEntity>` formatında context'e göstermemiz gerekiyor. Ki Entity Framework DB tarafındaki hangi tabloyu code tarafındaki hangi sınıf ile eşleştireceğini bilsin.

![Ekran görüntüsü 2022-03-12 215426](https://user-images.githubusercontent.com/89224500/158030987-911e746d-7761-44f1-935c-90d86df07d12.png)
- Bu DBContext'e göre EF database üzerindeki aşağıdaki 2 tabloyu oluşturur.
![Ekran görüntüsü 2022-03-12 215530](https://user-images.githubusercontent.com/89224500/158031013-c05a7600-cd3a-4ece-87d6-938d030cb8d9.png)

Bir entity sınıfında 2 tip property yani özellik bulunabilir. Bunlar:

- `Scalar Property`: Primitive type olan field'lar olarak düşünebilirsiniz. Db de data tutan kolonlara karşılık gelir. Students tablosundan yola çıkarsak her bir skalar property için aşağıdaki gibi tablo kolonları oluşur.

![Ekran görüntüsü 2022-03-12 215744](https://user-images.githubusercontent.com/89224500/158031088-3c4967b8-810f-44b5-9cea-042ca860af85.png)
- `Navigation Property`: Navigation Property bir entity ile başka bir entity arasında olan ilişkiyi temsil eder.
- `Refererence Navigation Property`: Entity nin başka bir entity'e yi property olarak barındırması anlamına gelir. Entity framework bu 2 tabloyu birbirine Foreign Key ile bağlar.

![Ekran görüntüsü 2022-03-12 215932](https://user-images.githubusercontent.com/89224500/158031138-bf89c580-59b7-479b-ad7d-6b2038c004cf.png)

`Yukarıdaki örnek kodu incelersek Student entity si içerisinde Grade entity sinin var olduğunu görüyoruz. Bu demek oluyor ki Grade Student için bir referans tablo. EF Student tablosu içerisinde GradeId ismiyle bir FK tutarak bu iki tabloyu birbirine bağlar.`

![Ekran görüntüsü 2022-03-12 220133](https://user-images.githubusercontent.com/89224500/158031202-cc120f82-1b32-4ced-aca7-27092754e36e.png)

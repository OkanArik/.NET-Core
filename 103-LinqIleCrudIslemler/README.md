# Linq İle Crud İşlemler
Bu repomda sadece ders ilerleyişimdeki işlediğim konuların örnekleri var.Proje halinde değil!

---

# LINQ (Language Integrated Query)
- LINQ .Net Framework 3.5 ve Visual Studio 2008 ile hayatımıza giren farklı data source yani veri kaynaklarını sorgulamamıza yarayan bir dildir. LINQ Visual Basic ve C# ile birlikte kullanılabilir.
- Linq IQuerayable sınıflar ve IQuerayable'dan türeyen sınıflarla birlikte kullanılabilir. EF Core ile yarattığımız context'in elemanları yani tabloların koddaki karşıklıkları DBSet tipindedir. DBSet de IQuerayable sınıfından türeyen bir sınıftır. Dolayısıyla LINQ kullanılarak DBSet'ler üzerinde sorgulama yapılabilir.

Başlıca önemli LINQ metotları şu şekilde: `Bu methodlar program.cs file'ımda uygulamaları ile bulunmaktadır!`

- `Find()`: DBSet sınıfı ile kullanılabilen bir metottur. İlgili DbSet üzerinden Primary Key olarak tanımlanan alana göre arama yapmak için kullanılır.
- `First/FirstOrDefault()`:First ve FirstOrDefault birden fazla verinin olabileceği sorgulamaların sonunda listedeki ilk elemanı seçmek için kullanılır.


`Önemli`: First() ve FirstOrDefault() arasındaki temel fark; eğer listede veri bulunamazsa First() hata fırlatırken, FirstOrDefault() geriye null döndürür. Bu nedenle FirstOrDefault() ile veriyi çekip daha sonradan verinin null olup olmadığını kontrol etmek daha doğru bir yaklaşım olur.

- `SingleOrDefault()`:Sorgulama sonunda kalan tek veriyi geri döndürür. Eğer listede birden fazla eleman varsa hata döndürür. Listede hiç eleman yoksa geriye null döndürür.
- `ToList()`:Sorgulama sonucunu geriye koleksiyon olarak döndürmek için kullanılır.
- `OrderBy/OrderByDescending()`:OrderBy() bir listeyi sıralamak için kullanılır. OrderBy() varsayılan olarak Ascending sıralama sunar. Tersi sıralamak için OrderByDescending() kullanılmalıdır.
- `Anonymous Object Result`:LINQ her zaman geriye entity objesi dönmek zorunda değildir. Query sonucunu kendi yarattığınız bir obje formatında döndürebilirsiniz.


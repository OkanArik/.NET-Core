# Action Methodlar
- Bu dosyamda basit bir BookStore webapi tasarımı başlangıcında yaptığım çalışmalarımın class'ları bulunmaktadır.Adım adım derslerim ilerlerken bana ve yararlanmak isteyen arkadaşlara kılavuzluk etmesi açısından commitliyorum.Buradaki ana nokta BookStoreController da action methodların yaratılması.External veya inmemory database kullanılmadığından resource şablonu olarak yaratılan Book class'ının nesneleri yaratılarak static BookList'e atandı ve üzerinden Http request ve Http responselar gözlemledi. Static BookList tercih edilmesinin sebebi ise static BookList'in lifecycle'ı programın çalıştığı süreç olması oldu.
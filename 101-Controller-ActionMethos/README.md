# Action Methodlar
- Bu dosyamda basit bir BookStore webapi tasarımı başlangıcında yaptığım çalışmalarımın class'ları bulunmaktadır.Adım adım derslerim ilerlerken bana ve yararlanmak isteyen arkadaşlara kılavuzluk etmesi açısından commitliyorum.Buradaki ana nokta BookStoreController da action methodların yaratılması.External veya inmemory database kullanılmadığından resource şablonu olarak yaratılan Book class'ının nesneleri yaratılarak static BookList'e atandı ve üzerinden Http request ve Http responselar gözlemledi. Static BookList tercih edilmesinin sebebi ise static BookList'in lifecycle'ı programın çalıştığı süreç olması oldu.

---
# CMD ile WebApi projesi oluşturma ve VsCode da açma:
- cd Masüstü
- Masaüstü> mkdir NewFolder
- cd NewFolder
- Masaüstü\NewFolder> dotnet new webapi -n WebApi --framework net5.0
- Masaüstü\NewFolder> dotnet new sln WebApiSln 
- Masaüstü\NewFolder> dotnet sln add Webapi
- Masaüstü\NewFolder> code .
---
- cd = change directory
- mkidr = make directory

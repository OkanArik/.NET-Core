# Http Protokolü
- Neden Http protokolü bizim için önemli? Çünkü `.NET 5 versiyonunu kullanarak webapi'lar tasarlıcaz ve webapi'lar rest servis mimarisinde, restful servislerdir.Rest servislerde Http protokolü ile çalışmaktadır.`
# Http Nedir?
- `Hyper Text Transfer Protokol kelimelerinin baş harflerinden meydana gelen bir metin aktarım protokolüdür. Protokol oluşu ise bu veri aktarımının kurallarının önceden belirlenmiş olmasından gelir.`
- Örnek olarak statik bir web site düşünelim. Web site içerisinde yüzlerce nesne farklı formatlarda bulunur, buna css, imaj ve videolar dahildir. Http protokolü bu web sayfalarının (genelde html formatta olurlar) client(istemci) ve server(sunucu) arasındaki bu alışverişten sorumludur.
# Client - Server
- `Client'ları istemciler yani bilgisayarınızdaki tarayıcılar gibi düşünebilirsiniz. Siz tarayıcınızın adres çubuğuna bir url(uniform resource loader) yazdığınızda uzaktaki bir sunucudan bir talepte bulunursunuz.` Burda istemci sizin yerinize tarayıcınızdır, yani Client.
- `Server yani sunucu ise tarayıcınız aracılığıyla bulunduğunuz isteği karşılayan, eğer uygun ise size cevabı dönen makinedir.`
- `Http protokolü client-server mimarisi ile çalışır. Yani tarayıcınız sunucuya isteği Http aracılığıyla gönderir.`
- `Bir server'a birden fazla client aynı anda istekte bulunabilir. Ama client'ların birbirinden haberi yoktur. Client'lar ve server arasındaysa Http Request ve Http Response'ları gider gelir.`
- `Http arka planda internet üzerinden paket aktarımı protokolü olan TCP(Transmission Control Protocol) protokolünü kullanır.`
# Http Request Metotları (Http İstek Metotları)
Aşağıdaki Http Metotları ile `CRUD(Create-Read-Update-Delete)` işlemler yapabiliriz.
- `HTTP GET` ==>READ
- `HTTP POST` ==>CREATE
- `HTTP PUT` ==>UPDATE
- `HTTP DELETE` ==>DELETE
# Http Responses (Http Cevapları)

Örnek Http Cevabı:

![Ekran görüntüsü 2022-03-11 180601](https://user-images.githubusercontent.com/89224500/157892907-66223609-24c9-405a-b9e3-541a81594ae1.png)

`Response temelde aşağıdaki yapılardan oluşur;`
- `Durum Satırı:` Http protokolünün versiyonu, durum kodu, durum kodunun mesaj olarak karşılığından oluşur. Yukarıdaki örnekte : HTTP/1.1 200 OK Bu satıra baktığımızda kolaylıkla Http 1.1 protokolünün kullanıldığını isteğe karşılık 200 durum kodu döndüğünü ve OK mesajına karşılık geldiğini okuyabiliyoruz. bir Http request'i gönderdiğimizde dönen response içerisinde ilk baktığımız yer genelde durum satırı olur. Çünkü burası çağrımın statüsünü içerir.
- `Date:` Sunucunun istemcinin çağrısında cevap verdiği, tarihtir.
- `Server:` Sunucu ile ilgili bilgiyi içerir.
- `Content Type:` Sunucunun geri gönderdiği nesnenin türünü içerir.
- `Response Body:` Sunucunun döndüğü veriyi içeren bölümdür.
# Http Durum Kodları
- `Sunucudan bir istekte bulunduğumuzda sunucu durum satırında bu çağrının başarılı olarak gercekleşip gerçeklemediği bilgisini döner.` Eğer çağrım sırasında bir hata oluştuysa hatayı tanımlayacak kodu da burda döner.
- Ortak dil konuşulması adına Http Protokolünün sunmuş olduğu bazı durum kodları vardır.
`En temelde bilinmesi gereken kodlar aşağıdaki gibidir.`
- `200: OK (İstek başarılı)`
- `401: Unauthorized (Yetki Hatası)`
- `403: Forbidden (Hatalı Erişim İsteği)`
- `404: Not Found (Kaynak bulunamadı)`
- `500: Internal Server Error (Sunucu içerisinde hata oluştu)`
---
# HTTP response status codes

HTTP response status codes indicate whether a specific HTTP request has been successfully completed. Responses are grouped in five classes:

- 1)`Informational responses (100–199)`
- 2)`Successful responses (200–299)`
- 3)`Redirection messages (300–399)`
- 4)`Client error responses (400–499)`
- 5)`Server error responses (500–599)`
# HTTP
- `Hypertext Transfer Protocol (HTTP) is an application-layer protocol for transmitting hypermedia documents, such as HTML. It was designed for communication between web browsers and web servers, but it can also be used for other purposes. HTTP follows a classical client-server model, with a client opening a connection to make a request, then waiting until it receives a response. HTTP is a stateless protocol, meaning that the server does not keep any data (state) between two requests.`

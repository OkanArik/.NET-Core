# Action Methodlar

`Controller'lardan bahsederken benzer eylem gruplarını kapsayan sınıflar olduğundan bahsetmiştik. Action metotları ise bir resource üzerinde gerçekleştirilebilecek eylemler olarak düşünebilirsiniz. Yapıları itibariyle normal metot tanımından bir farkları yoktur. Http request'leri karşılayıp, servis içerisinde gerekli işlemler tamamlandıktan sonra http response'ları geri döndüren metotlardır.`


Eylemlere parametre geçmenin birden fazla yolu vardır. En çok kullanılan 3 yöntem `FromBody` , `FromQuery` ve `FromRoute` attribute'leri kullanılarak yapılanlardır.


- `FromBody`: Http request inin body'si içerisinde gönderilen parametreleri okumak için kullanılır.
- `FromQuery`: Url içerisine gömülen parametreleri okumak için kullanılan attribute dur.İfade string olarak okunur.
- `FromRoute`: Endpoint url'i içerisinde gönderilen parametreleri okumak için kullanılır. Yaygın olarak resource'a ait id bilgisi okurken kullanılır.


Örnek Action Metot:

![Ekran görüntüsü 2022-03-11 195333](https://user-images.githubusercontent.com/89224500/157911249-dc2adc3a-d07a-4045-8a3b-623f16da3775.png)

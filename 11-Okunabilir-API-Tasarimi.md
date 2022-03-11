# Okunabilir API Tasarımı

Okunabilir API'lar tasarlamak sizin developerlar ile ortak bir dil konuşabilmeniz için oldukça önemlidir. Projeye sizden sonra dahil olacak developlerların sadece içgüdüsel olarak endpointe baktığında hangi amaçla yaratıldığını anlayabiliyor olması gerekir. Aynı zamanda API'nizi kullanacak olan diğer developerlar da ilk bakışta bir API'ın isimlendirmesinden hangi amaçla kullanıldığını rahatlıkla anlayabilmelidir.


Bu amaçla okunabilir API tasarlamak için aşağıdaki genel kurallara dikkat edilerek API isimlendirmek doğru bir yöntem olacaktır.

- `Aksiyon ifadelerinden kaçınılmalı` : Aksiyon ifadelerini sizin yerinize http verb'leri zaten yapacaktır, bu nedenle isimlendirme yapılırken aksiyon ifadelerinden kaçınılmalıdır.
- `Controller yani resource isimlendirmesi çoğul olacak şekilde yapılmalı.` Doğası gereği aslında bu kaynakların çoğul yani birden fazla olduğunu göz önünde bulundurmalıyız.

![Ekran görüntüsü 2022-03-11 195557](https://user-images.githubusercontent.com/89224500/157911671-7a3b24f6-571d-45e7-b4b8-c54d8c9383bb.png)

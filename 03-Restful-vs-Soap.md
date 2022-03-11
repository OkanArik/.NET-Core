# Restful vs Soap
- SOAP (Simple Object Access Protocol) uygulamalar ile web servislerin bilgi aktarımını sağlayan XML tabanlı bir protokoldür. Yani web servise giden bilgi XML olarak gönderilir, web servis bu bilgiyi yorumlar ve sonucunu XML olarak geri döndürür. SOAP tabanlı bir web servisin, gönderilen XML verisini nasıl yorumlayacağının tanımlanması gerekir. Bu web servis tanımlaması WSDL standardı ile yapılır.

![Ekran görüntüsü 2022-03-11 185034](https://user-images.githubusercontent.com/89224500/157900621-74e1928e-d46f-40b8-8cf4-03418edbfe24.png)
# Rest Servislerde İletişim Seviyesinde Güvenlik
- Genellikle bir ön çağrı yapılarak, istemci sunucuya kendisini tanıtan bir istekte bulunur. Sunucu client'a yetki vermek isterse client'ın gnderdiği bilgilere istinaden bir token oluşturur. Ve istemcinin sonraki isteklerde token içerisinde belirtilen süre boyunca bu token ile birlikte gelmesi beklenir. Token geçerli olduğu sürece sunucu istemciyi tanır ve request'lerine cevap verir.

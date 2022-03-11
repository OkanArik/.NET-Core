# Controller Nedir ?
- `Benzer eylemleri tanımlamak ve gruplamak için kullanılır. Rest servis mimarisindeki resource'ların karşılığıdır. Benzer eylemlerin bir arada olması toplu halde yönetilebilmeleri için önemli. Yani bir controller içindeki eylemlere erişimi toplu halde yönetmek, erişimi kısıtlamak isteyebilirsiniz. Bu nedenle api tasarımı yaparken controller ları doğru tasarlamak ve eylemlerini gruplamak önemlidir.`
- `Controller sınıfları ControllerBase sınıfından kalıtım alır.` Aşağıda örnek bir kontroller sınıfı görebilirsiniz.

Örnek Controller:


![Ekran görüntüsü 2022-03-11 194714](https://user-images.githubusercontent.com/89224500/157910222-6dd568d9-21e4-49ec-9605-f8742d9952b2.png)


- `[ApiController] Attribute`: Controller eylemlerinin bir Http response döneceğini taahhüt eden attribute dur.

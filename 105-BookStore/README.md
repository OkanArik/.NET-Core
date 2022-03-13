# REFACTOR
- Projemde view modeller ile UI a client'a göstercem verileri kontrol altına alarak sadece adminin görmesi gereken verileri koruma altına aldım.
- Diğer Http methodları olan Put ve Post içinde model yaratarak onun üzerinde işlemlerimi yerime getirdim, bu sayede clientin sadece update edebileceği verileri belirledim ayrıca post işlemi içinde clientten verileri isticem türleri ayarladım.
- İd primary key kolonunun entity framework core sayesinde yararlandığım attribute ile otoincrement hale getirdim.
# Projemin son halinde görseller:
![Ekran görüntüsü 2022-03-13 200250](https://user-images.githubusercontent.com/89224500/158070459-49ea7a32-71a5-4622-8f9c-5bb64112fb74.png)
![Ekran görüntüsü 2022-03-13 200321](https://user-images.githubusercontent.com/89224500/158070477-ba6ee8df-a37f-424d-a7b5-6b43e3c3a78d.png)
![Ekran görüntüsü 2022-03-13 200353](https://user-images.githubusercontent.com/89224500/158070498-409e5f6e-732c-4584-8272-e1faa0a118c3.png)

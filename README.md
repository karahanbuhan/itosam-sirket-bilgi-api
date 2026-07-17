# ŞirketBilgi API
Şirketlerin hisse isimlerini, market ve defter değerlerini JSON ile yayınlayan basit bir API. Manuel olarak scrapper sonuçlarının API'a aktarılması gerekmektedir, bir pipeline yoktur.

/companies-2026-06-30: sonucu aşağıdaki formatta API üzerinden verilir
```JSON
...
{
    "companyName": "TGSAS",
    "bookValue": 2553000000,
    "marketValue": 24.04
},
{
    "companyName": "THYAO",
    "bookValue": 451260000000,
    "marketValue": 700.28
},
{
    "companyName": "TIRE",
    "bookValue": 7958722914,
    "marketValue": 2.65
},
...
```

## Kullanılan Araçlar
Visual Studio Code üzerinden .NET, C#, C# Dev Kit ve Python eklentileri ile hazırlanmıştır.

## Kurulum & Çalıştırma
0. `git clone https://github.com/karahanbuhan/itosam-sirket-bilgi-api.git` ile projeyi bilgisayarınıza klonlayın.
1. `cd itosam-sirket-bilgi-api` yazarak ilgili klasörün içine girin.
2. Bilgisayarınızda Python 3.x sürümünün yüklü olduğuna emin olun. Bu adresten gerekli yazılım dilini indirebilirsiniz: https://www.python.org/downloads/
3. `python ./Scrapper.py` yazarak programı çalıştırın, ekranda `new Company("DGNMO", 3006500000, 4.20),` gibi yazıların geldiğini göreceksiniz.
4. Bu yazıları program durunca `Program.cs` içerisine uygun bir dizi açıp yerleştirin ve MapGet ile döndürün.
5. Geliştirme/debug amaçlı ASP.NET ile başlatmak için kullanılan araçlardaki eklentileri yükleyin. Program.cs dosyası açılıyken üst sekmeden Run diyin ve C#, sonrasında http seçeneğini seçin.
6. Debug konsolda gözüken porttan oluşturduğunuz yeni MapGet adresine girin. Örnek olarak: `https://localhost:7288/companies-2026-06-30`
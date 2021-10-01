# WebService Detective

Eski bir uygulamadaki web servis ve web servis metotlarını kodu statik analiz yoluyla tarayarak bulmak istersek ne yapabiliriz sorusuna Roslyn'den de destek alıp bakmaya çalışıyoruz.

__Motivasyon__ : Legacy bir .net uygulaması içinde kullanılan web servis ve web servis metotlarının statik kod analizi ile çıkarılması isteniyor. Birazda Roslyn' den yararlanarak bunu nasıl sağlayabiliriz?

## Başlangıç

Senaryo gereği içinde çeşitli tipte sınıflar ve web servisler barındıran bir proje var. AmigaWorld bu amaçla tasarlanmış dummy tipte bir proje. İşe yarar hiçbir şey yapmıyor ama Roslyn tarafını kandırmak için değişik tuzaklar içermekte. Örneğin Service klasörü içinde WebService olmayan tipler var(ya da Entity klasöründe). Bu tiplere bakmayıp WebService niteliğini(attribute) uygulayan ve içinde WebMethod niteliği kullanan operasyonları ele almamız gerekiyor.

![./Assets/screenshot_1.png](./Assets/screenshot_1.png)

Amaç GamersService.asmx ve MagazineService.asmx ile içindeki web metotları yakalamak.

## Gelişim

Çözüme Roslyn kullanan bir Console uygulaması eklenir.

___devam edecek___
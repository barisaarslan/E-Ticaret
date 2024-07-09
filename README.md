# E-Ticaret Web Uygulaması

Bu proje, ASP.NET Core MVC ve Entity Framework Core kullanılarak geliştirilmiş bir e-ticaret web uygulamasıdır. Kullanıcılar ürünleri listeleyebilir, sepete ekleyebilir, ve sipariş verebilirler. Sipariş bilgileri kullanıcıdan alınır ve veritabanında saklanır.

## Özellikler

- Kullanıcı kayıt ve giriş işlemleri
- Ürün ekleme, listeleme, ve stok kontrolü
- Sepete ürün ekleme ve çıkarma
- Kullanıcı bilgilerinin alındığı ve siparişin tamamlandığı bir sepet sayfası
- Sipariş onay ekranı

## Kurulum

1. Bu repository'yi klonlayın:

    ```bash
    git clone https://github.com/kullanici_adi/e-ticaret-uygulamasi.git
    cd e-ticaret-uygulamasi
    ```

2. Gerekli bağımlılıkları yükleyin:

    ```bash
    dotnet restore
    ```

3. Veritabanı migrasyonlarını uygulayın:

    ```bash
    dotnet ef database update --context ApplicationDbContext
    ```

4. Uygulamayı çalıştırın:

    ```bash
    dotnet run
    ```

## Kullanım

### Kullanıcı Kayıt ve Giriş


![Ekran Resmi 2024-07-10 00 23 19](https://github.com/barisaarslan/E-Ticaret/assets/55956179/11b83c10-0f7a-4171-a091-37d8786d7115)

#### Giriş Yap

![Ekran Resmi 2024-07-10 00 23 15](https://github.com/barisaarslan/E-Ticaret/assets/55956179/36825aec-2ec4-43af-9883-9b6c1a6c4758)

### Ürün Listeleme ve Sepete Ekleme


#### Ürün Listeleme
![Ekran Resmi 2024-07-10 00 23 09](https://github.com/barisaarslan/E-Ticaret/assets/55956179/cabdc2f5-df51-479a-93eb-a72fb2b271fa)

#### Sepete Ekleme

![Ekran Resmi 2024-07-10 00 23 41](https://github.com/barisaarslan/E-Ticaret/assets/55956179/852bf658-b13c-48f7-9a0d-bee30dbd3d37)

Ürün listesi sayfasında `Sepete Ekle` butonuna tıklayarak ürünleri sepete ekleyebilirsiniz.

### Sepet ve Sipariş Tamamlama

#### Sepet

![Ekran Resmi 2024-07-10 00 22 50](https://github.com/barisaarslan/E-Ticaret/assets/55956179/196772ae-f78f-4543-b9d5-cd1873207f87)

#### Sipariş Tamamlama
Sepet sayfasında, kullanıcıdan isim, soyad, telefon ve adres bilgilerini alarak siparişinizi tamamlayabilirsiniz.

### Sipariş Onayı

![Ekran Resmi 2024-07-10 00 23 00](https://github.com/barisaarslan/E-Ticaret/assets/55956179/89cae85e-b8e0-4164-8b05-596174f25883)

## Ekran Görüntüleri

#### Anasayfa

![Ekran Resmi 2024-07-10 00 23 33](https://github.com/barisaarslan/E-Ticaret/assets/55956179/5e05cec7-2748-46db-9776-33a6ae09ab34)

#### Ürün Ekle
![Ekran Resmi 2024-07-10 00 23 41](https://github.com/barisaarslan/E-Ticaret/assets/55956179/66712c3a-97e5-408d-b5d5-8d7dda3d3cd7)

## Çalışma Mantığı

1. **Kullanıcı Kayıt ve Giriş**: Kullanıcılar `Kayıt Ol` ve `Giriş Yap` sayfaları aracılığıyla hesap oluşturabilir ve sisteme giriş yapabilirler.
2. **Ürün Listeleme ve Sepete Ekleme**: Giriş yapmış kullanıcılar, ürünleri listeleyebilir ve sepete ekleyebilirler. Her ürün için stok kontrolü yapılır.
3. **Sepet ve Sipariş Tamamlama**: Kullanıcılar sepetlerine ekledikleri ürünleri görüntüleyebilir, ürünleri çıkarabilir ve sipariş bilgilerini girerek siparişlerini tamamlayabilirler.
4. **Sipariş Onayı**: Sipariş tamamlandıktan sonra kullanıcıya bir sipariş numarası gösterilir ve bu bilgi veritabanında saklanır.

## Katkıda Bulunma

Eğer bu projeye katkıda bulunmak isterseniz, lütfen bir pull request gönderin veya bir sorun bildirimi oluşturun. Katkılarınız için teşekkür ederiz!

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakın.

## İletişim

Herhangi bir sorunuz veya geri bildiriminiz varsa, lütfen [barisaarslan98@hotmail.com] adresinden bizimle iletişime geçin.



# 🛒 E-Commerce Web Application

Bu proje, **ASP.NET Core 8** kullanılarak geliştirilmiş, katmanlı mimariye sahip bir e-ticaret uygulamasıdır. Admin Paneli ve Kullanıcı Paneli bulunmaktadır.
Amaç, modern yazılım geliştirme pratiklerini uygulayarak öğrenmek ve gerçek hayata yakın bir sistem tasarlamaktır.  

---
 # 🛒 ÖZET
  -Site içinde ürünler listelenmektedir. Kullanıcı seçimine göre(renk-kategori-beden-fiyat) ürünler listelenebilir. 
  -Ürün sepete eklenmek istenirse "Giriş Yapınız" uyarısı alınır.(Burada kullanıcının Authantice olup olmadığı kontrol edilir). 
  -Giriş yapmamış kullanıcı Giriş/ Kayıt ekranına yönlendirilir.
  -Kullanıcı adı ve şifresiyle giriş yapan kullanıcı sepetini görüntülemek istediğinde;
    aktif sepeti yoksa => sepet oluşturulur. Status durumu true atanır. Kullanıcı ürün ekledikçe kullanıcıya özel oluşan sepete ürünü eklenir. 
    aktif sepeti varsa => Sepet sayfasında mevcutta bulunan ürünleri listelenir ve yeni seçtiği ürün eklenir/güncellenir.(AJAX)
    (Sepet Status durumu Enum ile tutulmaktadır.)
  -


## 🛠️ Kullanılan Teknolojiler

### 🔹 Ana Teknolojiler
- **ASP.NET Core 8 (MVC + Web API)** → Uygulamanın temel çatısı, hem API hem WebUI geliştirme sağlandı.  
- **Entity Framework Core (Code First)** → Veritabanı işlemleri yönetildi, entityler arasında ilişkiler (1-N, N-N) kuruldu ve LINQ ile sorgulamalar yapıldı.  
- **Identity & JWT Authentication** → Kullanıcı giriş/çıkış süreçlerinde token tabanlı kimlik doğrulama yapıldı; ayrıca admin controller tarafında yetkilendirme ve sepet işlemlerinde güvenlik sağlandı.
  **JWT Token Konfigürasyonu** → API üzerinde gelen JWT token'ların doğrulanması sağlandı. 
  Token’ın **issuer** ve **audience** değerleri kontrol edildi, **yaşam süresi (lifetime)** doğrulandı ve token’ın uygulamaya ait olduğu **security key ile garanti altına alındı**. 
  Ayrıca, kullanıcı adı token içindeki **Name claim** üzerinden çekilerek `User.Identity.Name` ile erişim sağlandı. 
  Bu sayede API endpoint’lerine güvenli erişim ve yetkilendirme gerçekleştirildi. 
- **CQRS + MediatR** → Komut ve sorgu işlemleri ayrılarak temiz mimari sağlandı.  
- **AutoMapper** → Entity ↔ DTO dönüşümleri kolaylaştırıldı.  
- **Repository Pattern** → Veri erişimi soyutlandı, test edilebilirlik ve esneklik sağlandı.  

### 🔹 Diğer Teknolojiler & Best Practices
- **Dependency Injection** → Servislerin bağımlılıkları yönetildi, loosely coupled yapı kuruldu.  
- **LINQ** → Veriler üzerinde güçlü ve okunabilir sorgulamalar yapıldı.  
- **Fluent Validation / Data Annotations** → Kullanıcı girişleri ve modeller doğrulandı.  
- **Model Binding** → HTTP isteklerindeki veriler otomatik olarak modellere bağlandı.  
- **RESTful API** → Katmanlar arası iletişim sağlandı; WebUI ve API arasında JSON tabanlı veri alışverişi yapıldı, HTTP metotları (GET, POST, PUT, DELETE) kullanıldı ve stateless yapısıyla ölçeklenebilirlik sağlandı.
- **Ajax & jQuery** → WebUI tarafında asenkron veri işlemleri yapıldı. (Sepet güncelleme işlemleri => ürün adeti arttırma/azaltma, toplam fiyat ; Ürün kategori seçimleri)
- **View Components** → Sayfa üzerinde birden fazla entity veya bileşen dinamik olarak gösterildi.  

## 📂 Katmanlar
- `MyProject.Api` → Web API katmanı  
- `MyProject.WebUI` → MVC/WebUI katmanı  
- `MyProject.Business` → İş kuralları katmanı  
- `MyProject.DataAccess` → Veri erişim katmanı  
- `MyProject.Entity` → Entity sınıfları  
- `MyProject.DTO` → DTO sınıfları  

---




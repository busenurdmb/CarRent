#  CQRS ve Mediator ile Araba Kiralama Sitesi Filtreleme İşlemi
M&Y Yazılım Eğitim Akademi Danışmanlık bünyesinde CQRS-Mediator  öğrenmek için yapılan 7. Projedir.

# CQRS -Mediator Nedir?
CQRS (Command Query Responsibility Segregation)
CQRS, komutlar (commands) ve sorguların (queries) sorumluluklarını ayırarak sistemin karmaşıklığını azaltan bir tasarım desenidir.
Bu desen, yazma işlemlerini (komutlar) ve okuma işlemlerini (sorgular) ayrı ele alır, böylece her iki işlemi de optimize etmeye olanak tanır.

Mediator Tasarım Deseni
Mediator tasarım deseni, nesneler arasındaki iletişimi merkezi bir bileşen üzerinden gerçekleştirir. 
Bu, doğrudan nesneler arası bağımlılıkları azaltır ve sistemi daha modüler hale getirir.
Mediator deseninde, bir merkezi aracı (mediator) tüm iletişim trafiğini yönetir.

# Temel Prensipler ve Avantajlar
-➡️Sorumluluk Ayrımı: CQRS, komutlar (commands) ve sorguların (queries) sorumluluklarını ayırarak sistemin karmaşıklığını azaltır.
-➡️Esneklik ve Genişletilebilirlik: Yeni filtreleme kriterleri eklemek veya mevcut olanları değiştirmek kolaydır, bu da sistemi esnek ve genişletilebilir yapar.
-➡️Nesneler Arası Bağımlılık Azaltma: MediatR, nesneler arası bağımlılığı azaltır ve sorguların ve komutların merkezi bir aracıyı kullanarak yönlendirilmesini sağlar.

🛞 Proje Örneği: Filtreleme Senaryosu
Bu proje, bir araba kiralama sitesinde araçları filtrelemek için kullanılan bir CQRS ve MediatR uygulamasını simüle eder. 
Kullanıcılar, alış lokasyonu, teslim ediş lokasyonu ve tarihleri girerek uygun araçları filtrelerler.. İşte sürecin adımları:
⌨️Kullanıcı Girişi: Kullanıcı, alış lokasyonu, teslim ediş lokasyonu ve tarihleri girer.
🧑‍💻Sorgu Oluşturma ve Gönderme: Kullanıcı girişi alındıktan sonra, bu bilgilerle bir sorgu (query) oluşturulur ve MediatR aracılığıyla işlenmek üzere gönderilir.
❓Sorgu İşleme: Sorgu, ilgili sorgu işleyicisi (query handler) tarafından işlenir ve veritabanından ilgili araç bilgileri getirilir.
📜Sonuçların Gösterimi: Filtreleme sonuçları kullanıcıya gösterilir.

♟️ Örnek Senaryo:

- 1-Kullanıcı, alış lokasyonu olarak "Atatürk Havaalanı", teslim ediş lokasyonu olarak "Sabiha Gökçen Havaalanı" ve tarih aralığını girer.
- 2-Sorgu, bu kriterlere uygun araçları getirmek için işlenir.
- 3-Veritabanında bu kriterlere uygun araçlar bulunur ve kullanıcıya gösterilir. 

🌍Sonuç
CQRS ve MediatR tasarım desenleri, kompleks iş süreçlerini yönetmek ve farklı yetki seviyeleri gerektiren işlemleri etkili bir şekilde işlemek için güçlü araçlardır.
Araba kiralama senaryosu gibi durumlarda bu desenler, işlemlerin sıralı ve düzenli bir şekilde yönetilmesini sağlar, 
böylece sistem daha esnek, genişletilebilir ve bakımı kolay hale gelir..

💻 Kullanılan Teknolojiler ve Yapılar:
- 🤖 .NET Core 6.0 ->Web uygulamasının temel çerçevesi olarak kullanıldı ✅
- 🎐 Entity Framework (ORM) 6.0 - >Veritabanı etkileşimi ve ORM (Nesne İlişkilendirme Haritası) için kullanıldı.✅
-  ©️ CQRS  tasarım deseni - ✅
- Ⓜ️ Mediator tasarım deseni - ✅
- 🎡 Code First -> Veritabanı şeması,uygulamaada yazılıp veri tabanı aktarıldı✅
- 🔐 Cookie Yönetimi -> Kullanıcı oturum yönetimi için kullanıldı, kullanıcı tercihlerini ve oturum bilgilerini depolar.- ✅
- 💻 Microsoft SQL Server (MSSQL) Veritabanı->Veritabanı yönetimi ve depolama için kullanıldı.- ✅
- 🎨 HTML-CSS-Bootstrap (Arayüz tasarımı için) - ✅
- ⌨️ LINQ - ✅

   ![d](https://github.com/busenurdmb/CarRent/blob/master/CarRent/wwwroot/Ads%C4%B1z%20tasar%C4%B1m.gif)
   ![d](https://github.com/busenurdmb/CarRent/blob/master/CarRent/wwwroot/download%20(1).gif)
   ![d](https://github.com/busenurdmb/CarRent/blob/master/CarRent/wwwroot/vbcqrs.png)

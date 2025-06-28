<h1 align="center">🔌 SmartHomeAPI</h1>

<p align="center">
  A modern and modular RESTful API built with ASP.NET Core for managing smart home environments — from locations and devices to sensors and analytics.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-7.0-blue?style=flat-square" />
  <img src="https://img.shields.io/badge/EF--Core-PostgreSQL-green?style=flat-square" />
  <img src="https://img.shields.io/badge/JWT-Auth-yellow?style=flat-square" />
  <img src="https://img.shields.io/badge/Swagger-UI-brightgreen?style=flat-square" />
</p>

---

## ✨ Layihə Xülasəsi

**SmartHomeAPI** — ağıllı ev texnologiyaları üçün hazırlanmış server-tərəfli tətbiqdir. Bu API istifadəçilərə evlərində və ya ictimai məkanlarda yerləşdirilmiş cihazları və sensorları idarə etmək imkanı verir.

Layihənin əsas məqsədi **lokasiyaya bağlı cihaz və sensorları idarə etmək, istifadəçi rolu ilə girişləri məhdudlaşdırmaq və real zamanlı enerji istifadəsi və cihaz sağlamlığı ilə bağlı analitik hesabatlar təqdim etməkdir**.

Bu API, həm **ev avtomatlaşdırma sistemlərinə**, həm də **kommersiya məqsədli smart infrastrukturlara** rahatlıqla inteqrasiya edilə bilər.

---

## 🚀 Texnologiyalar

- **.NET 7**
- **ASP.NET Core Web API**
- **Entity Framework Core (PostgreSQL)**
- **ASP.NET Identity & JWT Authentication**
- **AutoMapper**
- **Swagger / OpenAPI**
- **Modular Layered Architecture**

---

## ⚙️ Quraşdırma (Quickstart)

### 1. Reponu klonla:
```bash
git clone https://github.com/istifadeci-adiniz/SmartHomeAPI.git
cd SmartHomeAPI
```

### 2. `appsettings.json` konfiqurasiyası:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=SmartHomeDb;Username=postgres;Password=sifreniz"
},
"Jwt": {
  "Issuer": "SmartHomeAPI",
  "Audience": "SmartHomeClients",
  "SecretKey": "super-secret-key"
}
```

### 3. Migration və Database:
```bash
dotnet ef database update
```

### 4. Run:
```bash
dotnet run
```

---

## 🔐 Giriş və Rol Sistemi

- İstifadəçi login olduqda JWT token alır
- Rollar: `Admin`, `Member`
- Endpoint-lərə çıxış rola görə `Authorize` attribute ilə idarə olunur

#### Token göndərmək üçün:
```
Authorization: Bearer eyJhbGciOi...
```

---

## 🔧 Əsas Modullar

| Modul          | İmkanlar                                                 |
|----------------|-----------------------------------------------------------|
| **Lokasiyalar** | Yaratmaq, siyahılamaq, cihazlarla birlikdə görüntüləmək |
| **Cihazlar**    | Əlavə et, dəyişdir, sil, lokasiyaya bağla               |
| **Kateqoriyalar** | Cihaz kateqoriyalarını idarə et                         |
| **Sensor Məlumatları** | Real vaxtlı sensor datalarının saxlanması          |
| **Analitika**   | Enerji istifadəsi, cihaz sağlamlığı və lokasiya statistikası |

---

## 📊 Swagger UI

> Layihəni başladıqdan sonra Swagger UI mövcuddur:

```
https://localhost:7266/swagger/index.html
```

### Test etmək üçün:
1. `Authorize` düyməsinə klik et
2. Token daxil et:
   ```
   Bearer eyJhbGciOi...
   ```

---
## 🔧 Əsas Funksionallıq

### 📍 Lokasiya İdarəetməsi
- Yeni lokasiyalar əlavə et
- Lokasiya üzrə cihazları və sensorları görüntülə
- Bütün lokasiyaları göstər

### 🔌 Cihazlar və Kateqoriyalar
- Cihazlar əlavə et, redaktə et, sil
- Cihaz statusları: `Active`, `Inactive`
- ID-yə əsasən cihazın detalları

### 🌡 Sensor Məlumatları
- Cihazlardan gələn ölçmələri qeydiyyata al
- Ölçmələr tarixi ilə birlikdə saxlanılır
- Son sensor oxunuşu

### 📊 Analitika və Hesabatlar
- Enerji istifadəsi üzrə statistika
- Cihaz sağlamlıq göstəriciləri
- Lokasiya üzrə aktiv cihaz sayları və yük
- Cihaz sağlamlıq hesabatı
---

## 📁 Layihə Quruluşu

```
SmartHomeAPI/
│
├── Business/           # Servis məntiqi və DTO-lar
├── Core/               # Entity modelləri və enum-lar
├── DataAccess/         # EF konteksti və repositiories
├── Controllers/        # API endpoint-lər
├── Middlewares/        # Custom middleware-lar
└── Program.cs          # Başlatma nöqtəsi
```

---

## 📦 Əsas Paketlər

| Paket | Təyinat |
|-------|---------|
| `Microsoft.AspNetCore.Authentication.JwtBearer` | JWT tokenləri ilə auth |
| `Npgsql.EntityFrameworkCore.PostgreSQL`         | PostgreSQL dəstəyi      |
| `AutoMapper.Extensions.Microsoft.DependencyInjection` | DTO mapping          |
| `Swashbuckle.AspNetCore`                        | Swagger UI             |
| `Microsoft.AspNetCore.Identity.EntityFrameworkCore` | İstifadəçi və rol idarəsi |

---

## 👤 Müəllif

**Aysun E.**  
🎓 AzInTelecom təcrübə proqramı taskı çərçivəsində hazırlanmışdır 
📅 2025  
🌐 GitHub: [EminliAysun05](https://github.com/EminliAysun05)

---

## 🤝 Töhfə Vermək

PR və ya məsələlər (issues) göndərməkdən çəkinməyin. Təmiz kod prinsiplərinə uyğunluq və modulların bölünməsi prioritetdir.

# 🎮 Catálogo de Videojuegos

Aplicación web desarrollada en **ASP.NET Core MVC** con arquitectura multicapa (Clean Architecture).
Permite explorar, agregar y reseñar videojuegos, con sistema de autenticación de usuarios.

---

## 🏗️ Arquitectura

El proyecto sigue el patrón **Clean Architecture** dividido en 4 capas:

```
CatalogoApp/
│
├── Catalogo.Domain/                  # Núcleo — modelos e interfaces
│   ├── Models/
│   │   ├── Item.cs
│   │   ├── User.cs
│   │   └── Review.cs
│   └── Interfaces/
│       ├── IItemRepository.cs
│       ├── IUserRepository.cs
│       └── IReviewRepository.cs
│
├── Catalogo.Application/             # Lógica de negocio
│   └── Services/
│       ├── ItemService.cs
│       ├── UserService.cs
│       └── ReviewService.cs
│
├── Catalogo.Infrastructure/          # Persistencia — JSON
│   └── Repositories/
│       ├── JsonItemRepository.cs
│       ├── JsonUserRepository.cs
│       └── JsonReviewRepository.cs
│
└── Catalogo.Presentation/            # ASP.NET MVC — capa visual
    ├── Controllers/
    │   ├── CatalogoController.cs
    │   ├── UserController.cs
    │   └── ReviewController.cs
    ├── Views/
    │   ├── Catalogo/
    │   │   ├── Index.cshtml
    │   │   ├── Detalle.cshtml
    │   │   └── Agregar.cshtml
    │   ├── Home/
    │   │   ├── Index.cshtml
    │   │   └── Privacy.cshtml
    │   ├── User/
    │   │   ├── Login.cshtml
    │   │   └── Register.cshtml
    │   └── Shared/
    │       └── _Layout.cshtml
    ├── data/                          # Base de datos JSON
    │   ├── items.json
    │   ├── users.json
    │   └── reviews.json
    ├── wwwroot/
    │   ├── css/site.css
    │   └── js/site.js
    └── Program.cs
```

---

## ✨ Funcionalidades

- 🎮 **Catálogo** — Listado de videojuegos con filtro por género
- 🔍 **Detalle** — Vista individual con rating promedio y reseñas
- ➕ **Agregar** — Formulario para añadir nuevos videojuegos
- ⭐ **Reseñas** — Sistema de rating del 1 al 5 con comentarios
- 👤 **Autenticación** — Registro e inicio de sesión de usuarios
- 🗑️ **Eliminar** — Eliminación de videojuegos del catálogo

---

## 🛠️ Tecnologías

| Tecnología | Uso |
|---|---|
| ASP.NET Core MVC (.NET 10) | Framework web |
| C# | Lenguaje principal |
| JSON | Persistencia de datos |
| Bootstrap 5 | Estilos base |
| Font Awesome 6 | Iconografía |
| Google Fonts (Audiowide, Press Start 2P, Exo 2) | Tipografía |
| Session | Autenticación de usuarios |

---

## 🎨 Diseño

Estilo **retro neon** con paleta fucsia/morado y animación de piezas de Tetris cayendo en el fondo.
Los colores y fuentes se controlan desde variables CSS en `wwwroot/css/site.css`.

```css
/* Para cambiar el color principal de toda la app */
--neon-principal: #ff00ff;
```

---

## 🚀 Cómo ejecutar

1. Clona el repositorio:
```bash
git clone https://github.com/JorgeTSW/CatalogoApp.git
```

2. Abre la solución en **Visual Studio 2022** o superior.

3. Establece `Catalogo.Presentation` como proyecto de inicio.

4. Ejecuta con **IIS Express** o `dotnet run`.

5. La carpeta `data/` se crea automáticamente con los archivos JSON al iniciar.

---

## ⚠️ Nota de seguridad

Este es un proyecto **educativo**. Las contraseñas se almacenan en texto plano.
No uses contraseñas reales ni lo despliegues en producción sin implementar hashing (BCrypt, PBKDF2, etc.).

---

## 👤 Autor

**Jorge J. Pedrozo Romero** — [GitHub](https://github.com/JorgeTSW)

---

*Proyecto desarrollado con fines educativos — 2026*
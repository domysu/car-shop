# 🚗 Car sale project

A web-based car sale project for school project

---

## 📦 Technologies Used

- [.NET 8](https://dotnet.microsoft.com/)
- Blazor Server
- Entity Framework Core (with MySQL or SQLite)
- Tailwind CSS
- C#
- Razor Components

---

## 🚀 Getting Started

These instructions will get your local development environment up and running.

### 📁 1. Clone the repository

```bash
git clone https://github.com/domysu/car-shop.git
```

### 🔧 2. Install dependencies (for Tailwind CSS)

Make sure you have [Node.js](https://nodejs.org/) installed.

```bash
npm install
```

---

## 🎨 Tailwind CSS

### ⏱️ Watch for changes (during development)

This command generates `site.css` from your custom Tailwind styles:

```bash
npx tailwindcss -i ./wwwroot/css/input.css -o ./wwwroot/css/site.css --watch
```

---

## 💾 Database Setup

Make sure you have database available (MySQL or SQLite).  
Update the connection string in `Program.cs` accordingly.

### Using MySQL (example):

```csharp
options.UseMySql(
  "server=localhost;port=3306;database=automobiliai;user=root;password=yourpassword",
  ServerVersion.AutoDetect(...)
);
```

### Using SQLite (quick start):

```csharp
options.UseSqlite("Data Source=automobiliai.db");
```

### Apply migrations:

```bash
dotnet ef database update
```

---

## ▶️ Run the application

```bash
dotnet run
```




## 🛡️ .gitignore Tips

Make sure the following are ignored:

```
node_modules/
bin/
obj/
*.db
*.log
wwwroot/css/site.css
```

---

## 📄 License

MIT

---

## 🧙 Final Note

Built with 💻 and ☕ by Dominykas @ Klaipėda University.

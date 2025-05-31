# Car sale project



A web-based car sale project for school project

---

## Technologies Used

- [.NET 8](https://dotnet.microsoft.com/)
- Blazor
- PostgreSQL
- Tailwind CSS
- C#


---

##  Getting Started

These instructions will get your local development environment up and running.

#### Clone the repository

```bash
git clone https://github.com/domysu/car-shop.git
```



This command generates `site.css` from your custom Tailwind styles:

```bash
npx tailwindcss -i ./wwwroot/css/input.css -o ./wwwroot/css/site.css --watch
```


#### Make sure your database is up and running
**I used docker for my database** 

in `appsettings.json` add this
```
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=dbname;user=username;password=password"

  }
```


#### Apply migrations

```bash
dotnet ef database update
```


#### Run the application

```bash
dotnet run
```





---

## Demo

Currently live demo is not available

**Here some pics of the project**

![photo1](https://github.com/user-attachments/assets/eb855279-76a6-49f9-84d3-1dcefbf9f707)

![photo2](https://github.com/user-attachments/assets/cb03aa44-a2ed-4010-a072-6d0a7e87c2a4)



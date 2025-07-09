### 🔄 Lazy<T> Injection in ASP.NET Core

#### ✅ What is it?
`Lazy<T>` allows deferred creation of a dependency. The object is only created when `.Value` is accessed.

#### ⚠️ Problem
Microsoft’s default DI container **does not support Lazy<T> out of the box**.

#### ✅ Solution: Create a `LazyFactory<T>`

```csharp
    public class LazyFactory<T> : Lazy<T>
    {
        public LazyFactory(IServiceProvider sp)
            : base(() => sp.GetRequiredService<T>()) {}
    }
    services.AddTransient(typeof(Lazy<>), typeof(LazyFactory<>));
```
---

## ✅ Résumé 2 — Data Seeding in ASP.NET Core

### 🌱 Data Seeding Mechanisms in ASP.NET Core

ASP.NET Core + EF Core allows two distinct approaches for seeding your data:

---

#### 🔹 1. Design-Time Seeding with `.HasData()` (EF Core)

Implemented in your `IEntityTypeConfiguration<T>` class.

```csharp
public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category { Id = 1, Name = "SUV" },
            new Category { Id = 2, Name = "Sedan" }
        );
    }
}
```
### 2 App runtime before calling app.Run()

```csharp
public static class AppSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

        if (!await context.Categories.AnyAsync())
        {
            context.Categories.Add(new Category { Name = "SUV" });
            await context.SaveChangesAsync();
        }

        if (await userManager.FindByEmailAsync("admin@site.com") == null)
        {
            await userManager.CreateAsync(new AppUser
            {
                UserName = "admin",
                Email = "admin@site.com"
            }, "Admin@123");
        }
    }
}
```
 ### And in Program.cs:

```csharp

    var app = builder.Build();
    await AppSeeder.SeedAsync(app.Services);
```
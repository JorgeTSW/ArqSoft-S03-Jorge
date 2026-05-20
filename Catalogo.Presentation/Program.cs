using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Ruta base de los JSON
var dataPath = Path.Combine(builder.Environment.ContentRootPath, "data");

// Repositorios
builder.Services.AddSingleton<IItemRepository>(
    new JsonItemRepository(Path.Combine(dataPath, "items.json"))
);
builder.Services.AddSingleton<IUserRepository>(
    new JsonUserRepository(Path.Combine(dataPath, "users.json"))
);
builder.Services.AddSingleton<IReviewRepository>(
    new JsonReviewRepository(Path.Combine(dataPath, "reviews.json"))
);

// Servicios
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<ReviewService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
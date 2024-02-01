using Exercice04.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Ajoutez des services au conteneur.

builder.Services.AddDbContext<MarmosetDbContext>();

//builder.Services.AddDbContext<MarmosetDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("MarmosetDatabase")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddSingleton<FakeMarmosetDb>(); // Ne pas oublier sinon l'injection de dépendances de ce service ne fontionne pas

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

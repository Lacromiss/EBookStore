using Core.Repositories.Interfaces;
using DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Services.Implementations;
using Services.Interfaces;
using Core.Repositories;
using DAL.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Hizmet Kayıtları

//var services = new ServiceCollection();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

builder.Services.AddHttpContextAccessor();


builder.Services.AddDbContext<EBookStoreDbContext>();

// MVC Yapılandırması

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

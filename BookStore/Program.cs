using Core.Repositories.Interfaces;
using DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Services.Implementations;
using Services.Interfaces;
using Core.Repositories;
using DAL.Concrete;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Core.Entities.Account;
using System;
using Services.Utilites;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddIdentity<AppUser, IdentityRole>()
                                 .AddEntityFrameworkStores<EBookStoreDbContext>()
                                 .AddDefaultTokenProviders();
        builder.Services.Configure<IdentityOptions>(opt =>
        {
            opt.Password.RequireDigit = true;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireLowercase = true;
            opt.Password.RequireUppercase = true;
            opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(3);

        });
        
// Hizmet Kayıtları

//var services = new ServiceCollection();
builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IBlogService, BlogService>();
        builder.Services.AddScoped<IBlogRepository, BlogRepository>();
        builder.Services.AddScoped<IAuthorService, AuthorService>();
        builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
        builder.Services.AddScoped<IContactService, ContactService>();
        builder.Services.AddScoped<IContactRepository, ContactRepository>();
        builder.Services.AddScoped<AppUser>();



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
    }
}
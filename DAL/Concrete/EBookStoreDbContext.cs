using EntityLayer.Concret;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class EBookStoreDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server =DESKTOP-LUJ8MVB; database=EBookStore; integrated security=true;TrustServerCertificate=True");
        }
     public  DbSet<Test>tests {  get; set; }
     public  DbSet<Blog> Blogs {  get; set; }
     public  DbSet<Book> Books {  get; set; }
     public  DbSet<ContactMe> ContactMes {  get; set; }
     public  DbSet<KeepInTouch> KeepInTouches {  get; set; }
     public  DbSet<Icon> Icons {  get; set; }
     public  DbSet<Sponsor> Sponsors {  get; set; }
     public  DbSet<Author> Authors {  get; set; }



    }
}

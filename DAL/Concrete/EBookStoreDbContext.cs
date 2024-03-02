﻿using DAL.Entities;
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
            options.UseSqlServer("server =DESKTOP-LUJ8MVB; database=EBookStoreee; integrated security=true;TrustServerCertificate=True");
        }
          public DbSet<Book> books {  get; set; }
          public DbSet<Blog> blogs {  get; set; }
          public DbSet<Author> authors {  get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Book:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string Page { get; set; }
        public double Price { get; set; }
        public double Lenght { get; set; }
        //relationWithAuthor
       public int AuthorId { get; set; }
        public Author? Author { get; set; }
      public float Raiting { get; set; }
    }
}

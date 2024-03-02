using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Author:BaseModel
    {
        public string AuthorFullName { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorPhone { get; set; }
        public string AuthorDescription { get; set; }
        public string ImgUrl { get; set; }
        public int PublishedBook { get; set; }
        //Details
        public string Country { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        //relationsWithBooks
        public List<Book>? Books { get; set; }
      public List<Blog>? Blogs { get; set; }

    }
}

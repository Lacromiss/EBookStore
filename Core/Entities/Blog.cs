using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Blog:BaseModel
    {
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        //relationWithBooks
       public int AuthorId { get; set; }
       public Author Author { get; set; }
    }
}

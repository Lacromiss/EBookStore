using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Blog:BaseModel
    {
        [Required(ErrorMessage = "ImgUrl is empty"),DataType(DataType.ImageUrl,ErrorMessage ="wrong format ")]

        public string ImgUrl { get; set; }
        [Required(ErrorMessage = "Title is empty"), MaxLength(500, ErrorMessage = "maks symbol lenght 500")]

        public string Title { get; set; }
        [Required(ErrorMessage ="Description is empty"),MaxLength(5000, ErrorMessage ="maks symbol lenght 5000")]
        public string Description { get; set; }
       
        public string Link { get; set; }
        //relationWithBooks
        [Required(ErrorMessage = "AuthorId is empty")]
        public int AuthorId { get; set; }
       public Author? Author { get; set; }
        public bool isFeatured { get; set; }
    }
}

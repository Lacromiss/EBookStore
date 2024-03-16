using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Author : BaseModel
    {
        [Required(ErrorMessage = "Title is empty"), MaxLength(40, ErrorMessage = "maks symbol lenght 40")]

        public string AuthorFullName { get; set; }
        [Required(ErrorMessage = "AuthorFullName is empty"), DataType(DataType.EmailAddress,ErrorMessage ="Wrong format")]

        public string AuthorEmail { get; set; }
        [Required(ErrorMessage = "AuthorEmail is empty"), DataType(DataType.PhoneNumber,ErrorMessage ="Wrong format")]

        public string AuthorPhone { get; set; }
        [Required(ErrorMessage = "AuthorDescription is empty"), MaxLength(40, ErrorMessage = "maks symbol lenght 40")]

        public string AuthorDescription { get; set; }
        [Required(ErrorMessage = "ImgUrl is empty")]

        public string ImgUrl { get; set; }
        [Required(ErrorMessage = "PublishedBook is empty"), ]

        public int PublishedBook { get; set; }
        //Details
        [Required(ErrorMessage = "Country is empty")]

        public string Country { get; set; }
        [Required(ErrorMessage = "Language is empty")]

        public string Language { get; set; }
        [Required(ErrorMessage = "Genre is empty")]
        public string Genre { get; set; }
        //relationsWithBooks
        public List<Book>? Books { get; set; }
        public List<Blog>? Blogs { get; set; }

    }
}

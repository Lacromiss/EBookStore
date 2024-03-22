using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Book:BaseModel
    {
        [Required(ErrorMessage = "Name is empty"), MaxLength(100, ErrorMessage = "maks symbol lenght 100")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Description is empty"), MaxLength(1000, ErrorMessage = "maks symbol lenght 1000")]



        public string Description { get; set; }
        [Required(ErrorMessage = "ImgUrl is empty"),DataType(DataType.ImageUrl,ErrorMessage ="wrong fotmat")]



        public string ImgUrl { get; set; }
        [Required(ErrorMessage = "Page is empty")]


        public string Page { get; set; }
        [Required(ErrorMessage = "Price is empty")]

        public double Price { get; set; }
        [Required(ErrorMessage = "Lenght is empty")]

        public double Lenght { get; set; }
        //relationWithAuthor
        [Required(ErrorMessage = "AuthorId is empty")]

        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        [Required(ErrorMessage = "Raiting is empty")]

        public float Raiting { get; set; }
        public bool isFeatured { get; set; }
        public int Count { get; set; }

    }
}

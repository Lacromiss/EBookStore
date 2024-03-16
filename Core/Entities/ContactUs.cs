using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ContactUs:BaseModel
    {
        [Required(ErrorMessage = "Title is empty"), MaxLength(200, ErrorMessage = "maks symbol lenght 200")]


        public string Name { get; set; }
        [Required(ErrorMessage = "email is empty"), DataType(DataType.EmailAddress,ErrorMessage ="send your email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Phonenumber is empty"), DataType(DataType.EmailAddress, ErrorMessage = "send your Phonenumber")]

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Message is empty")]

        public string Message { get; set; }
        public bool RememberMe { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concret
{
    public class ContactMe:BaseModel
    {
        
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public bool RemindMe { get; set; }
    }
}

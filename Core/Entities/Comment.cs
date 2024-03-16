using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Comment:BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public short Raiting { get; set; }
        public string Name { get; set; }
    }
}

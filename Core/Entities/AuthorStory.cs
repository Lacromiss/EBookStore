using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AuthorStory:BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AuthorSkills> AuthorSkills{ get; set; }
    }
}

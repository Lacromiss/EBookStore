using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AuthorSkills:BaseModel
    {
        public string SkillsTitle { get; set; }
        public string Skills { get; set; }
        public int AuthorStoryId { get; set; }
        public AuthorStory AuthorStory { get; set; }

    }
}

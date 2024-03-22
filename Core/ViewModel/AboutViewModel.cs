using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class AboutViewModel
    {
        public List<Blog> Blogs { get; set; }
        public List<AuthorSkills> AuthorSkills { get; set; }
        public List<AuthorStory> AuthorStory { get; set; }

    }
}

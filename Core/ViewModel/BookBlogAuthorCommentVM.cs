using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class BookBlogAuthorCommentVM
    {
        public List<Book> Books { get; set; }
        public List<Comment>Comments { get; set; }
        public List<Author> Authors { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<AuthorSkills> AuthorSkills { get; set; }
        public List<AuthorStory> AuthorStories { get; set; }
    }
}

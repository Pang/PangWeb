using PangWeb.Shared;

namespace PangWeb.Services
{
    public class BlogService
    {
        private List<Blog>? blogs = new List<Blog>();

        public Blog GetBlogById(int id)
        {
            return blogs.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Blog> GetAllBlogs()
        {
            return blogs.OrderByDescending(x => x.Date).ToList();
        }

        public void AddNewBlog(Blog blogForm)
        {
            blogForm.Date = DateTimeOffset.Now;

            if (blogForm.Title != null && blogForm.Summary != null)
                blogs.Add(blogForm);
        }

        public BlogService()
        {
            blogs = new List<Blog>()
            {
                new Blog {
                    Title = "New stuff",
                    Date = DateTimeOffset.Parse("17/01/2021"),
                    Summary = "We gon be workin on a new game, LOTR-inspired with castles and fantasy stuff. Based in the same universe as ShieldMaidens"
                },
                new Blog {
                    Title = "In other news", 
                    Date = DateTimeOffset.Parse("14/03/2017"),
                    Summary = "This is a cool summary"
                },
                new Blog
                {
                    Title = "Just keep scrollin",
                    Date = DateTimeOffset.Parse("11/05/2015"),
                    Summary = "It really goes on..."
                },
            };
        }
    }
}

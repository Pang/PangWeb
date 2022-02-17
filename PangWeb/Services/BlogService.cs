using PangWeb.Shared;

namespace PangWeb.Services
{
    public class BlogService
    {
        private List<Blog> blogs;
        private int idTracker;

        public BlogService()
        {
            blogs = SeededData();
            idTracker = GetAllBlogs().Count();
        }

        /* Get a block by its ID */
        public Blog GetBlogById(int id)
        {
            return blogs.Where(x => x.Id == id).FirstOrDefault();
        }

        /* Get List of all blogs */
        public List<Blog> GetAllBlogs()
        {
            return blogs.OrderByDescending(x => x.Date).ToList();
        }

        /* Add a new blog to the list */
        public void AddNewBlog(Blog blogForm)
        {
            if (blogForm.Title != null && blogForm.Summary != null)
            {
                blogForm.Date = DateTimeOffset.Now;
                blogForm.Id = ++idTracker;
                blogs.Add(blogForm);
            }
        }

        private List<Blog> SeededData()
        {
            return new List<Blog>()
            {
                new Blog
                {
                    Id = 1,
                    Title = "Just keep scrollin",
                    Date = DateTimeOffset.Parse("11/05/2015"),
                    Summary = "It really goes on..."
                },
                new Blog {
                    Id = 2,
                    Title = "In other news",
                    Date = DateTimeOffset.Parse("14/03/2017"),
                    Summary = "This is a cool summary"
                },
                new Blog {
                    Id = 3,
                    Title = "New stuff",
                    Date = DateTimeOffset.Parse("17/01/2021"),
                    Summary = "We gon be workin on a new game, LOTR-inspired with castles and fantasy stuff. Based in the same universe as ShieldMaidens"
                },
            };
        }
    }
}

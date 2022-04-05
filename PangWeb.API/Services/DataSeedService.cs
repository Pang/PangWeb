using PangWeb.API.Data;
using PangWeb.Shared;

namespace PangWeb.API.Services
{
    public class DataSeedService
    {
        public DataSeedService(DataContext context)
        {
            context.Database.EnsureCreated();
            if (context.Blogs.Any()) return;

            var blogs = new Blog[]
            {
                new Blog { Title = "Test One", Summary = "Lorem ipsum dolor sit amet", Date = DateTimeOffset.Now, active = true, ImgUrl = "https://picsum.photos/200" },
                new Blog { Title = "Test Two", Summary = "Consectetur adipiscing elit", Date = DateTimeOffset.Now, active = true, ImgUrl = "https://picsum.photos/200" },
                new Blog { Title = "Test Three", Summary = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", Date = DateTimeOffset.Now, active = true, ImgUrl = "https://picsum.photos/200" },
                new Blog { Title = "Test Four", Summary = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris", Date = DateTimeOffset.Now, active = true, ImgUrl = "https://picsum.photos/200" },
            };

            foreach (var blog in blogs)
            {
                context.Blogs.Add(blog);
            }
            context.SaveChanges();
        }
    }
}

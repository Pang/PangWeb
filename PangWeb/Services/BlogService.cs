﻿using PangWeb.Shared;
using System.Text.Json;

namespace PangWeb.Services
{
    public class BlogService
    {
        private readonly HttpClient _httpClient;
        public List<Blog> blogs;
        private int idTracker;

        public BlogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /* Get a blog by its ID */
        public Blog GetBlogById(long id)
        {
            return blogs.Where(x => x.Id == id).FirstOrDefault();
        }

        /* Get List of all blogs */
        public async Task<List<Blog>> GetAllBlogs()
        {
            var requestMsg = new HttpRequestMessage(HttpMethod.Get, "api/Blog/GetAll");
            var response = await _httpClient.SendAsync(requestMsg);

            if (response.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<List<Blog>>(await response.Content.ReadAsStreamAsync());
            return new List<Blog>();
        }

        /* Get List of all blogs */
        public List<Blog> GetAllBlogsAdmin()
        {
            // todo: check admin
            return blogs.OrderByDescending(x => x.Date).ToList();
        }

        /* Add a new blog to the list */
        public bool AddNewBlog(Blog blogForm)
        {
            if (blogForm.Title != null && blogForm.Summary != null)
            {
                blogForm.Date = DateTimeOffset.Now;
                blogForm.Id = ++idTracker;
                blogForm.ImgUrl = "https://picsum.photos/400";
                blogs.Add(blogForm);
                return true;
            }
            return false;
        }

        /* Save an editted blog from the list */
        public bool SaveEdittedBlog(Blog blogForm)
        {
            if (blogForm.Title != null && blogForm.Summary != null)
            {
                var blogIndex = blogs.FindIndex(x => x.Id == blogForm.Id);
                blogs[blogIndex] = blogForm;
                return true;
            }
            return false;
        }

        /* Disable blog from list */
        public void DeleteBlog(Blog blogForm)
        {
            // todo: check admin
            if (blogForm != null)
            {
                var blogIndex = blogs.FindIndex(x => x.Id == blogForm.Id);
                blogs[blogIndex].active = false;
            }
        }

        /* Reactivate blog from list */
        public void ReactivateBlog(Blog blogForm)
        {
            // todo: check admin
            if (blogForm != null)
            {
                var blogIndex = blogs.FindIndex(x => x.Id == blogForm.Id);
                blogs[blogIndex].active = true;
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
                    Summary = "It really goes on...",
                    ImgUrl = "https://picsum.photos/400",
                    active = true,
                    Date = DateTimeOffset.Parse("11/05/2015"),
                },
                new Blog {
                    Id = 2,
                    Title = "In other news",
                    Summary = "This is a cool summary",
                    ImgUrl = "https://picsum.photos/400",
                    active = true,
                    Date = DateTimeOffset.Parse("14/03/2017"),
                },
                new Blog {
                    Id = 3,
                    Title = "New stuff",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    ImgUrl = "https://picsum.photos/400",
                    active = true,
                    Date = DateTimeOffset.Parse("17/01/2021"),
                },
            };
        }
    }
}

using PangWeb.Shared;
using System.Text.Json;

namespace PangWeb.Services;

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

    /* Get List of latest blogs */
    public async Task<List<Blog>> GetAllBlogs()
    {
        var requestMsg = new HttpRequestMessage(HttpMethod.Get, "api/Blog/GetLatest");
        var response = await _httpClient.SendAsync(requestMsg);

        if (response.IsSuccessStatusCode)
            return await JsonSerializer.DeserializeAsync<List<Blog>>(await response.Content.ReadAsStreamAsync());
        return new List<Blog>();
    }

    /* Get List of all blogs */
    public async Task<List<Blog>> GetAllBlogsAdmin()
    {
        var requestMsg = new HttpRequestMessage(HttpMethod.Get, "api/Blog/GetAll");
        var response = await _httpClient.SendAsync(requestMsg);

        if (response.IsSuccessStatusCode)
            return await JsonSerializer.DeserializeAsync<List<Blog>>(await response.Content.ReadAsStreamAsync());
        return new List<Blog>();
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
            blogs[blogIndex].Active = false;
        }
    }

    /* Reactivate blog from list */
    public void ReactivateBlog(Blog blogForm)
    {
        // todo: check admin
        if (blogForm != null)
        {
            var blogIndex = blogs.FindIndex(x => x.Id == blogForm.Id);
            blogs[blogIndex].Active = true;
        }
    }
}

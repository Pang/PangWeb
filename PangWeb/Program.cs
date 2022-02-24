using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PangWeb;
using PangWeb.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7220") } );
builder.Services.AddSingleton<BlogService>();
builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<UserService>();

await builder.Build().RunAsync();

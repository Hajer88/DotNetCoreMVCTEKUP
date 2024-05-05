using Microsoft.EntityFrameworkCore;
using Project.FirstMVC._2024.Models;
using Project.FirstMVC._2024.Repositories.Repositories;
using Project.FirstMVC._2024.Repositories.RepositoriesContract;
using Project.FirstMVC._2024.Services.Services;
using Project.FirstMVC._2024.Services.ServicesContracts;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityDataContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityDataContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
var connstring = builder.Configuration
    .GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>
    (options => options.UseSqlite(connstring));
builder.Services.AddRazorPages();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseWelcomePage("/");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;
//endpoint hello world lorsque le path / est appelé

app.UseAuthorization();
app.MapGet("/",()=> "Hello world");
//Endpoint retourne c# object serialisé en JSOn data
//app.MapGet("Movietest", () => new Movie("Movie1"));
//Chaque requêute se mappe à un handler unique
app.MapGet("Product/Test1", () => "Test1");
app.MapGet("Product/Test2", () => "Test2");
//URl se mappe à un handler unqieu et Query string est
//utilisée pour montrer les data dynamiques
//product?name=produit1
app.MapGet("product", (string name)=>name);
//1. annote le route avec le nom hello
//2. génére une réponse qui envoie une redirection
// à l'endpoint hello

app.MapGet("/test/{id}", () => "hello world")
    .WithName("Hello");
app.MapGet("/redirect-me",
    ()=>Results.RedirectToRoute("hello"));
app.MapRazorPages();
//Routing mapps url to a single handler and the url
//segment identifies dynamic data
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?" +
    "}");

app.Run();


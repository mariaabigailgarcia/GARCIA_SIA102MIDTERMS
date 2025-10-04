using Microsoft.EntityFrameworkCore;
using GARCIA_SIA102Midterms.Data;
using GARCIA_SIA102Midterms.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register DbContext with connection string
builder.Services.AddDbContext<pubsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories (example for Authors)
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
//builder.Services.AddScoped<ITitleRepository, TitleRepository>();
//builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Microsoft.EntityFrameworkCore;
using YogaSix.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(); // ✅ Add this line

builder.Services.AddDbContext<YogaSixContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("YogaSixContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // ✅ Needed to serve CSS/JS

app.UseRouting();

app.UseAuthorization(); // ✅ Now safe to use

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

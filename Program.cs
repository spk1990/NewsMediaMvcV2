using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsMediaMvc.Models;
using Microsoft.AspNetCore.Identity;
using NewsMediaMvc.Areas.Identity.Data;
using NewsMediaMvc.Data;
using System;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CommentsContext>(options =>



    options.UseSqlite(builder.Configuration.GetConnectionString("CommentsContext")));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<NewsMediaDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("NewsMediaDbContext")));
}
else
{
    builder.Services.AddDbContext<NewsMediaDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionNewsMediaDbContext")));
}
builder.Services.AddDbContext<NewsMediaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("NewsMediaDbContext")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<NewsMediaMvcIdentityDbContext>();builder.Services.AddDbContext<NewsMediaMvcIdentityDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("NewsMediaDbContext")));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

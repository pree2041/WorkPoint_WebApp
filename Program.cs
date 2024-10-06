using Microsoft.EntityFrameworkCore;
using WorkPoint_WebApp;
using WorkPoint_WebApp.Data;
using WorkPoint_WebApp.Service.Contract;
using WorkPoint_WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(x =>
{
    x.AddProfile(new MappingProfile(new HttpContextAccessor()));
}
);

builder.Services.AddScoped<INewsService, NewsService>();
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
    pattern: "{controller=News}/{action=View}");

app.Run();

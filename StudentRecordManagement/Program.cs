
using Microsoft.EntityFrameworkCore;
using StudentRecordManagement.MyModels;

//using StudentRecordManagement.MyModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();
//builder.Services.AddDbContext<StudentRecordContext>(x => 
//    x.UseSqlServer("Data Source=.;Initial Catalog=StudentRecord;User Id=sa;Password=p@ssw0rd; MultipleActiveResultSets=true"));

builder.Services.AddDbContext<StudentRecordContext>(x =>
    x.UseSqlServer(
        "Data Source=.;Initial Catalog=StudentRecord;User Id=sa;Password=p@ssw0rd; MultipleActiveResultSets=true"));

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

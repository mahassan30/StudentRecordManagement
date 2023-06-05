
using DataAccessLayer.MyModels;
using DataAccessLayer.Repositories;
using Interfacces.RepositoryInterface;
using Interfacces.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using Services.Services;

//using StudentRecordManagement.MyModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

//Eager Loading after Onion Architecture
builder.Services.AddDbContext<StudentRecordContext>(x =>
    x.UseLazyLoadingProxies().UseSqlServer(
        "Data Source=.;Initial Catalog=StudentRecord;User Id=sa;Password=p@ssw0rd; MultipleActiveResultSets=true"));
//Resolve Dependencies for Interfaces
builder.Services.AddScoped<IStudentInterface, StudentService>();
builder.Services.AddScoped<IClassInterface, ClassService>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();


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

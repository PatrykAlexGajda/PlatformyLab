using Microsoft.EntityFrameworkCore;
using Silownia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddDbContext<SilowniaContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("Server=(localdb)\\MSSQLLocalDB;Database=SILOWNIA_DB;Trusted_Connection=True;MultipleActiveResultSets=true")
builder.Services.AddDbContext<SilowniaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SilowniaContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

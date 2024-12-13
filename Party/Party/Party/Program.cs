using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Party.Business.Concrate;
using Party.Business.Concrate.Repositories;
using Party.Data.Concrate;
using Party.Data.Concrate.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ParticipantRepositories>();
builder.Services.AddScoped<ParticipantService>();
builder.Services.AddScoped<InvitationService>();
builder.Services.AddScoped<InvitationRepositories>();

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

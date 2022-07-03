using DataAccess.EFCore;
using DetectiveGame.Helpers;
using Microsoft.EntityFrameworkCore;
using DetectiveGame.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DetectiveGameContextConnection") ?? throw new InvalidOperationException("Connection string 'DetectiveGameContextConnection' not found.");

builder.Services.AddDbContext<ApplicationContext>(options =>
	options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<DetectiveGameUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationContext>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationContext")));

DIHelper.RegisterDependecy(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
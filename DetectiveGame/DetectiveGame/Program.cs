using DataAccess.EFCore;
using DetectiveGame.Helpers;
using Microsoft.EntityFrameworkCore;
using DetectiveGame.Domain.Entities;
using DetectiveGame.Domain.Entities.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationContext")
	?? throw new InvalidOperationException("Connection string 'ApplicationContext' not found.");

builder.Services.AddDbContext<ApplicationContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<SiteUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationContext>();

// Add services to the container.
builder.Services.AddRazorPages();


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
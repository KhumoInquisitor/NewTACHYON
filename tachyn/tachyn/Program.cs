using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Tachyon.Areas.Identity.Data;
using Tachyon.services;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("TachyonDbContextConnection ") ?? throw new InvalidOperationException("Connection string 'TachyonDbContextConnection' not found.");
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TachyonDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<TachyonUser>(options => options.SignIn.RequireConfirmedAccount = false)
   .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<TachyonDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEmailSender,EmailSender>();
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Procedure}/{action=land}/{id?}");


app.MapRazorPages();
using (var scope = app.Services.CreateScope())
{

    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<TachyonUser>>();
    
    string firstName = "David";
    string lastName = "James";
    string email = "admin@gmail.com";
    string password = "Admin@1";
    bool confirmEmail = true;
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new TachyonUser();
        user.FirstName = firstName;
        user.LastName = lastName;
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = confirmEmail;
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }

}
using (var scope = app.Services.CreateScope())
{

    var userManager =

    scope.ServiceProvider.GetRequiredService<UserManager<TachyonUser>>();

    string firstName = "Moshe";
    string lastName = "James";
    string email = "nurse@gmail.com";
    string password = "Nurse@1";
    bool confirmEmail = true;
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var Nurse = new TachyonUser();
        Nurse.FirstName = firstName;
        Nurse.LastName = lastName;
        Nurse.UserName = email;
        Nurse.Email = email;
        Nurse.EmailConfirmed = confirmEmail;
        await userManager.CreateAsync(Nurse, password);
        await userManager.AddToRoleAsync(Nurse, "Doctor");
    }

}
app.Run();

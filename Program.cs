using dotnetMVCIdentity.Data;
using dotnetMVCIdentity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using dotnetMVCIdentity.Interfaces;
using dotnetMVCIdentity.Helpers;
using dotnetMVCIdentity.Models;
using dotnetMVCIdentity.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddTransient<ISendGridEmail, SendGridEmail>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("SendGrid"));
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OnlyBloggerChecker", policy => policy.Requirements.Add(new OnlyBloggerAuthorization()));
    options.AddPolicy("CheckNicknameTeddy", policy => policy.Requirements.Add(new NicknameRequirment("teddy")));
});
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);
    options.Lockout.MaxFailedAccessAttempts = 5;
    //options.SignIn.RequireConfirmedAccount = true;
});
builder.Services.AddAuthentication()
    .AddFacebook(options =>
    {
        options.AppId = "1403970347207170";
        options.AppSecret = "139756ad201dde71ce2691b4d7d1a98a";
    })
    .AddGoogle(options =>
    {
        options.ClientId = "1087231995409-5jmn0lvov41ejecgtvqjik4js96v4t6e.apps.googleusercontent.com";
        options.ClientSecret = "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";
    });

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

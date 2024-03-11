using Blazored.LocalStorage;
using Business.Facades;
using Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using UI.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//database
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<LogicalcDbContext>(opts => opts.UseSqlServer(connectionString), ServiceLifetime.Transient);

//business layer
builder.Services.AddScoped<UserFacade>();
builder.Services.AddScoped<FormulaFacade>();
builder.Services.AddScoped<FeedbackFacade>();

//local storage services
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ThemeService>();

//auth
builder.Services.AddAuthentication();
builder.Services.AddScoped<AuthenticationStateProvider, UserAuthenticationStateProvider>();
builder.Services.AddScoped<AuthorizationTools>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

using DAF.Assesment.Flights.Application.Flights;
using DAF.Assesment.Flights.Core.Flights;
using DAF.Assesment.Flights.Infrastructure;
using DAF.Assesment.Flights.Web.Components;
using Microsoft.EntityFrameworkCore;
using DAF.Assesment.Flights.Infrastructure.Flights;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using DAF.Assesment.Flights.Application.Users;
using DAF.Assesment.Flights.Core.Users;
using DAF.Assesment.Flights.Infrastructure.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DafAssesmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DAFAssementDb")));

//Register Services for mine classes
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserEmailService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddBlazorise(o => { o.Immediate = true; }).AddBootstrapProviders().AddFontAwesomeIcons();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

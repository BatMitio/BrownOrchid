using BrownOrchid.Gateways.Portal.Providers;
using BrownOrchid.Gateways.Portal.Services.Client;
using BrownOrchid.Gateways.Portal.Services.Client.Interfaces;
using BrownOrchid.Gateways.Portal.Services.Dealer;
using BrownOrchid.Gateways.Portal.Services.Dealer.Interfaces;
using BrownOrchid.Gateways.Portal.Services.Employee;
using BrownOrchid.Gateways.Portal.Services.Employee.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(opt => opt.RootDirectory = "/Pages");
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthentication();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IDealerService, DealerService>();
builder.Services.AddScoped<TokenAuthenticationStateProvider, TokenAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();

builder.Services.AddHttpClient(builder.Configuration["Services:Employee:Client"], client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:Employee:Endpoint"]);
});

builder.Services.AddHttpClient(builder.Configuration["Services:Client:Client"], client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:Client:Endpoint"]);
});

builder.Services.AddHttpClient(builder.Configuration["Services:App:Client"], client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:App:Endpoint"]);
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Employee", policy => 
        policy.RequireClaim("role", "employee"));
    options.AddPolicy("Dealer", policy => 
        policy.RequireClaim("role", "dealer"));
    options.AddPolicy("Client", policy => 
        policy.RequireClaim("role", "client"));
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
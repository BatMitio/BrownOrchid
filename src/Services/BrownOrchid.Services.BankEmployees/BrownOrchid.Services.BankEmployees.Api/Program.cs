using BrownOrchid.Common.Application;
using BrownOrchid.Common.Application.Extensions;
using BrownOrchid.Services.BankEmployees.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddPersistence();
builder.Services.AddApplication(new[] { typeof(BankEmployeesDependencyInjection).Assembly });
builder.Services.AddBankEmployeesDependencyInjection();
builder.AddSecurity();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.EnsureDatabaseCreated();
app.UseSecurity();
app.MapControllers();

app.Run();
using AutoMapper;
using BrownOrchid.Common.Application;
using BrownOrchid.Common.Application.Extensions;
using BrownOrchid.Services.DWH.Data.Entities;
using BrownOrchid.Services.DWH.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddPersistence();

builder.Services.AddApplication(new[] { typeof(Dealer).Assembly });
builder.Services.AddDwhDependencyInjection();
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
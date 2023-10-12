using IBGE.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Localidades

app.MapGet("v1/ibges/city", (AppDbContext context, string city) =>
{
    var result = context.Ibges.AsNoTracking().Where(x => x.City == city).ToList();
    return result;
});

app.MapGet("v1/ibges/state", (AppDbContext context, string state) =>
{
    var result = context.Ibges.AsNoTracking().Where(x => x.State == state).ToList();
    return result;
});

app.MapGet("v1/ibges/codeIbge", (AppDbContext context, string codeIbge) =>
{
    var result = context.Ibges.AsNoTracking().Where(x => x.Id == codeIbge).ToList();
    return result;
});

#endregion

app.Run();

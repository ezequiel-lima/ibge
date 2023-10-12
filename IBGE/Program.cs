using IBGE.Data;
using IBGE.Models;
using IBGE.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Localidades

app.MapGet("v1/ibges/city", async (AppDbContext context, string city) =>
{
    var result = await context.Ibges.AsNoTracking().Where(x => x.City == city).ToListAsync();
    return result;
});

app.MapGet("v1/ibges/state", async (AppDbContext context, string state) =>
{
    var result = await context.Ibges.AsNoTracking().Where(x => x.State == state).ToListAsync();
    return result;
});

app.MapGet("v1/ibges/codeIbge", async (AppDbContext context, string codeIbge) =>
{ 
    var result = await context.Ibges.AsNoTracking().Where(x => x.Id == codeIbge).ToListAsync();
    return result;
});

app.MapPost("v1/ibges", async (AppDbContext context, CreateIbgeViewModel ibge) =>
{
    context.Ibges.Add(ibge.MapTo());
    await context.SaveChangesAsync();

    return Results.Created($"v1/ibges/{ibge.Id}", ibge);
});

app.MapPut("v1/ibges", async (AppDbContext context, string id, UpdateIbgeViewModel model) =>
{
    var result = await context.Ibges.FirstOrDefaultAsync(x => x.Id == id);

    if (result is null)
        Results.NotFound();

    result.Change(model);

    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("v1/ibges/codeIbge", async (AppDbContext context, string codeIbge) =>
{
    if (await context.Ibges.FindAsync(codeIbge) is Ibge ibge)
    {
        context.Ibges.Remove(ibge);
        await context.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

#endregion

app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<AppDbContext>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}



using IBGE.Data;
using IBGE.Models;
using IBGE.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IBGE.Endpoints
{
    public static class IbgeEndpoints
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("v1/ibges/city", async (AppDbContext context, string city) =>
            {
                var ibges = await context.Ibges.AsNoTracking().Where(x => x.City == city).ToListAsync();
                return ibges is not null && ibges.Count > 0 ? Results.Ok(ibges) : Results.NotFound();
            }).Produces<List<Ibge>>();

            app.MapGet("v1/ibges/state", async (AppDbContext context, string state) =>
            {
                var ibges = await context.Ibges.AsNoTracking().Where(x => x.State == state).ToListAsync();
                return ibges is not null && ibges.Count > 0 ? Results.Ok(ibges) : Results.NotFound();
            }).Produces<List<Ibge>>();

            app.MapGet("v1/ibges/codeIbge", async (AppDbContext context, string codeIbge) =>
            {
                return await context.Ibges.AsNoTracking().Where(x => x.CodeIbge == codeIbge).FirstOrDefaultAsync()
                    is Ibge ibge
                        ? Results.Ok(ibge)
                        : Results.NotFound();
            }).Produces<Ibge>();

            app.MapPost("v1/ibges", async (AppDbContext context, CreateIbgeViewModel model) =>
            {
                var ibge = model.MapTo();

                if (!model.IsValid)
                    return Results.BadRequest(model.Notifications);

                context.Ibges.Add(ibge);
                await context.SaveChangesAsync();

                return Results.Created($"v1/ibges/{ibge.Id}", ibge);
            });

            app.MapPut("v1/ibges", async (AppDbContext context, string codeIbge, UpdateIbgeViewModel model) =>
            {
                model.MapTo();

                if (!model.IsValid)
                    return Results.BadRequest(model.Notifications);

                var result = await context.Ibges.FirstOrDefaultAsync(x => x.CodeIbge == codeIbge);

                if (result is null)
                    Results.NotFound();

                result.Change(model);
                await context.SaveChangesAsync();

                return Results.NoContent();
            });

            app.MapDelete("v1/ibges/id", async (AppDbContext context, Guid id) =>
            {
                if (await context.Ibges.FindAsync(id) is Ibge ibge)
                {
                    context.Ibges.Remove(ibge);
                    await context.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });
        }
    }
}

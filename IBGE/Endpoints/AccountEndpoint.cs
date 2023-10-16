using IBGE.Data;
using IBGE.Models;
using IBGE.Services;
using IBGE.ViewModels;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace IBGE.Endpoints
{
    public static class AccountEndpoint
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("v1/accounts", async (AppDbContext context, RegisterViewModel model) =>
            {
                var password = PasswordGenerator.Generate(10);

                var user = new User(model.Email, PasswordHasher.Hash(password));

                context.Users.Add(user);
                await context.SaveChangesAsync();

                return Results.Ok(new
                {
                    user.Email,
                    password
                });
            }).AllowAnonymous();

            app.MapPost("v1/login", async (AppDbContext context, LoginViewModel model) =>
            {
                var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == model.Email);

                if (user is null)
                    return Results.NotFound(new { Message = "Invalid email or password" });

                if (!PasswordHasher.Verify(user.Password, model.Password))
                    return Results.Unauthorized();

                var token = TokenService.GenerateToken(user);

                user.CleanPassword();

                return Results.Ok(new
                {
                    user,
                    token
                });
            }).AllowAnonymous();
        }
    }
}

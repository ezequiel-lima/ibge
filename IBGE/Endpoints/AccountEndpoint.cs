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
                if (!model.Email.IsValid)
                    return Results.BadRequest(model.Email.Notifications);

                var existingUser = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Address == model.Email.Address);
                if (existingUser != null)
                    return Results.BadRequest(new { Message = "This email has already been registered" });

                var password = PasswordGenerator.Generate(10);

                var user = new User(model.Email, PasswordHasher.Hash(password));

                context.Users.Add(user);
                await context.SaveChangesAsync();

                return Results.Ok(new
                {
                    user.Email,
                    password
                });
            })
                .WithTags("Autenticação e Autorização")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Cadastra uma conta",
                    Description = "Regista uma nova conta de manager"
                })
                .AllowAnonymous();

            app.MapPost("v1/login", async (AppDbContext context, LoginViewModel model) =>
            {
                if (!model.Email.IsValid)
                    return Results.BadRequest(model.Email.Notifications);

                var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Address == model.Email.Address);

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
            })
                .WithTags("Autenticação e Autorização")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Realiza a autenticação de um usuário",
                    Description = "Gera um token de autenticação e retorna os detalhes do usuário"
                })
                .AllowAnonymous();
        }
    }
}

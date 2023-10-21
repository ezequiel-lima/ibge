using IBGE;
using IBGE.Data;
using IBGE.Endpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var key = Encoding.ASCII.GetBytes(Settings.Secret);

ConfigureServices(builder);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

#region Endpoints

IbgeEndpoint.Map(app);
AccountEndpoint.Map(app);

#endregion

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<AppDbContext>();

    #region Swagger

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(x =>
    {
        x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT is an Internet standard for creating data with optional signature and/or encryption, " +
            "whose content contains JSON that asserts a number of claims. Tokens are signed using a private secret or a public/private key.",
        });

        x.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string [] {}
            }
        });

        x.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "IBGE.API",
            Version = "v1",
            Contact = new OpenApiContact
            {
                Name = "João Ezequiel Lima",
                Email = "ezequiel.lima.br@gmail.com",
                Url = new Uri("https://www.linkedin.com/in/joao-ezequiel-lima/")
            }
        });
    });

    #endregion

    #region Authentication and Authorization

    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("Admin", policy => policy.RequireRole("manager"));
    });

    #endregion
}

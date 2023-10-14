using IBGE.Data;
using IBGE.Endpoints;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);

var app = builder.Build();

#region Endpoints

IbgeEndpoints.Map(app);

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
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

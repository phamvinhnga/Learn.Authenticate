using Infrastuctures.ServiceBuilders;
using Learn.Authenticate.Api.Services.ServiceBuilders;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerServiceBuilder(configuration);
builder.Services.UseSqlServiceBuilder(configuration);
builder.Services.UseMigrationServiceBuilder(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwaggerApplicationBuilder(configuration);
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Infrastuctures.ServiceBuilders;
using Learn.Authenticate.Api.Services.ServiceBuilders;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.UseSwaggerServiceBuilder(configuration);
builder.Services.UseSqlServiceBuilder(configuration);
builder.Services.UseMigrationServiceBuilder(configuration);
builder.Services.UseAutoMapperServiceBuilder(configuration);
builder.Services.UseInjectionServiceBuilder(configuration);
builder.Services.UseWebServiceBuilder(configuration);
builder.Services.UseAuthServiceBuilder(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwaggerApplicationBuilder(configuration);
}
app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

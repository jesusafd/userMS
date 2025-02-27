using System.Reflection;
using UserMS.Infrastructure;
using UserMS.Application;
var builder = WebApplication.CreateBuilder(args);


builder.Configuration.Sources.Clear();
builder.Configuration.AddJsonFile("appsettings.json", true)
                     .AddEnvironmentVariables()
                     .AddUserSecrets(Assembly.GetExecutingAssembly())
                     .AddEnvironmentVariables("ASPNETCORE_");
// Add services to the container.
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();

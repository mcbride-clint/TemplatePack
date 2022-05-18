using CompanyApp.Application;
using CompanyApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var isProduction = builder.Environment.IsProduction();
builder.Services.AddApplicationServices(isProduction);
builder.Services.AddInfrastructureServices(isProduction);

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

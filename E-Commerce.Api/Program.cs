using E_Commerce.Api.MiddleWares;
using E_Commerce.Infrastructure.Extensions;
using E_Commerce.Service.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(conf =>
{
    conf.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Commerce API", Version = "v1" });
});
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleWare>();
app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

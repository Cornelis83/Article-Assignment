using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BusinessLogics.ClassAdministration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddBusinessLogics();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options => 
{ 
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Article Assignment");
    options.DocumentTitle = "Swagger - Article Assignment";
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
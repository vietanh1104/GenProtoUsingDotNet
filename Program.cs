using autogenerate_proto;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Api Versioining Startup
builder.Services.AddApiVersioningStartup();
builder.Services.AddGrpc();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseStaticFiles();
app.UseSwaggerUI(o =>
{
    foreach (var description in provider.ApiVersionDescriptions)
    {
        o.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
            $"DemoApiVersioning - {description.GroupName.ToUpper()}");
        
    }
    o.InjectStylesheet("/SwaggerUI/index.css");

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

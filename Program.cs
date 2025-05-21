using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Moto Patio API",
        Version = "v1",
        Description = "API para gerenciamento de motos em pátios",
        Contact = new OpenApiContact
        {
            Name = "Seu Nome",
            Email = "seu.email@exemplo.com"
        }
    });
});

builder.Services.AddDbContext<MotoPatioContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build(); 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotoPatio API v1"));
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Moto Patio API V1");
    c.RoutePrefix = string.Empty; 
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
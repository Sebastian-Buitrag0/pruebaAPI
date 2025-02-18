using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using pruebaAPI.Data;
using pruebaAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add Services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Prueba API", Version = "v1" });
});

// Add Repositories to the container.
// builder.Services.AddSingleton<pruebaAPI.Repositories.IProductoRepository, pruebaAPI.Repositories.ProductoRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

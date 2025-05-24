using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using pruebaAPI.Data;
using pruebaAPI.Repositories;
using pruebaAPI.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using pruebaAPI.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add Services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "pruebaAPI", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
    In = ParameterLocation.Header, 
    Description = "Please insert JWT with Bearer into field",
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey 
  });
  c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   { 
     new OpenApiSecurityScheme 
     { 
       Reference = new OpenApiReference 
       { 
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer" 
       } 
      },
      new string[] { } 
    } 
  });
    
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:9000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,
             ValidIssuer = builder.Configuration["JWT:Issuer"],
             ValidAudience = builder.Configuration["JWT:Audience"],
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
         };
    });

// Add Repositories to the container.
// builder.Services.AddSingleton<pruebaAPI.Repositories.IProductoRepository, pruebaAPI.Repositories.ProductoRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IRoleRepository, RolRepository>();
builder.Services.AddScoped<IUserRespoitory, UserRepository>();
builder.Services.AddScoped<IUserDataRepository, UserDataRepository>();
builder.Services.AddScoped<IProductSale, ProductSaleRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ICashMovementsRepository, CashMovementsRepository>();
builder.Services.AddScoped<TokenGenerate>();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

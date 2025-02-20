using APIs.Data;
using APIs.Middleware;
using APIs.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();  // Add this
builder.Services.AddSwaggerGen();    // Add this for Swagger

// Database Context
builder.Services.AddDbContext<HRPayrollDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<HRPayrollDbContext>()
    .AddDefaultTokenProviders();

// Adding JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];

// Ensure the key is at least 32 characters (256 bits)
if (string.IsNullOrWhiteSpace(jwtKey) || Encoding.UTF8.GetBytes(jwtKey).Length < 32)
{
    throw new ArgumentException("JWT Key must be at least 256 bits (32+ characters). Update appsettings.json. and appsettings.Development.json.");
}

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtIssuer
    };
});

builder.Services.AddAuthorization();
builder.Services.AddControllers();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

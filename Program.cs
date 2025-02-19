using APIs.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();   // Add this
builder.Services.AddEndpointsApiExplorer();  // Add this
builder.Services.AddSwaggerGen();    // Add this for Swagger

builder.Services.AddDbContext<HRPayrollDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();
app.MapControllers();   // Add this

app.Run();

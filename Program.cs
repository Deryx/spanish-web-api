using Microsoft.EntityFrameworkCore;
using SpanishWebApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SpanishDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SpanishDb")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("SpanishTutorNext", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("SpanishTutorNext");
app.MapControllers();

app.Run();
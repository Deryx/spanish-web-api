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
        policy.WithOrigins(
                "http://localhost:3000",
                "https://spanish-tutor-next-c19u-eight.vercel.app")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    options.AddPolicy("FlutterDev", policy =>
    {
        policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();   // skip the redirect in development
}

app.UseRouting();
app.UseCors("SpanishTutorNext");
app.MapControllers();

app.MapGet("/health", () => "ok");
app.Run();
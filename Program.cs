using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using urlShortener.Data;
using urlShortener.Interfaces;
using urlShortener.Repository;
using urlShortener.Services;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();
Console.WriteLine(Environment.GetEnvironmentVariable("SupabaseDB")); // This should print your connection string.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(Environment.GetEnvironmentVariable("SupabaseDB"));
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUrlMapping, UrlRepository>();
builder.Services.AddTransient<UrlShortenerService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173") // Update with frontend URL
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

app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
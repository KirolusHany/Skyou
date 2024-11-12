using KikoStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoredContent>(
    opt=>opt.UseSqlServer(builder.Configuration
    .GetConnectionString("DefaultConnection"))
);

var app = builder.Build();


app.MapControllers();

app.Run();

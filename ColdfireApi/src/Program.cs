using ColdfireApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ColdfireDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ColdfireDatabase")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapBookRoutes();
app.MapCharacterRoutes();
app.MapHouseRoutes();

app.Run();
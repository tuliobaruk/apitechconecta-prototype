using apitechconecta_prototype.Configurations;
using apitechconecta_prototype.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<TechConectaService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region [Cors]
builder.Services.AddCors();
#endregion

var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region [Cors]
app.UseCors(c =>
{
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
    c.AllowAnyHeader();
});
#endregion

app.UseAuthorization();
app.MapControllers();
app.Run();
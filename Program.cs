using SpaceStation.DataLayer;
using SpaceStation.Interfaces;
using SpaceStation.Logic;
using SpaceStation.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddScoped<INasaLogic, NasaLogic>();
builder.Services.AddScoped<IRestWorker, RestWorker>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    int dontExpandModels = -1;
    app.UseSwaggerUI(options => options.DefaultModelExpandDepth(dontExpandModels));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

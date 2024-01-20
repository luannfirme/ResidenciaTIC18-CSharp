using TechMed.WebAPI.Infra.Data;
using TechMed.WebAPI.Infra.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.DependecyInjection();
builder.Services.AddSingleton<IDataBaseCollection, DataBase>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

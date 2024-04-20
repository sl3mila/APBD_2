using zadanie5;
using zadanie5.Properties;
using zadanie5.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

builder.Services.AddScoped<IAnimalsService, AnimalService>();
builder.Services.AddScoped<IAnimalsRepository, AnimalRepository>();

app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//2
app.MapGet("/api/animals", (IAnimalsService animalsService) =>
{
    
    var animals = animalsService.GetAnimals();
    
    return Results.Ok(animals);
});

//3
app.MapPost("/api/anmimals", (IAnimalsService animalsService, Animal animal) =>
{

    animalsService.CreateAnimal(animal);
    
    return Results.StatusCode(StatusCodes.Status201Created);
});

//4
app.MapPut("/api/animals/{idAnimal:int}", (IAnimalsService animalsService, int idAnimal, Animal animal) =>
{
    animalsService.EditAnimal(idAnimal, animal);
    
    return Results.NoContent();
});

//5
app.MapDelete("/api/animals/{idAnimal:int}", (IAnimalsService animalsService, int idAnimal) =>
{
    
    animalsService.DeleteAnimal(idAnimal);
    
    return Results.NoContent();
});

app.Run();

using Microsoft.AspNetCore.Http.HttpResults;
using zadanie4;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<IMockDb, MockDb>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/animals", (IMockDb mockDb) =>
{
    return Results.Ok(mockDb.GetAllAnimals());
}).WithName("GetAllAnimals");

app.MapGet("/animals/{id:int}", (IMockDb mockDb, int id) =>
{
    var animal = mockDb.GetAnimalById(id);
    if (animal == null)
    {
        return Results.NotFound();
    }
    
    return Results.Ok(animal);
}).WithName("GetAnimalsById");

app.MapPost("/animals/{id:int}", (IMockDb mockDb, int id) =>
{
    var animal = mockDb.GetAnimalById(id);
    if (animal == null)
    {
        return Results.NotFound();
    }
    
    mockDb.AddAnimal(animal);
    return Results.StatusCode(StatusCodes.Status201Created);
    
}).WithName("AddAnimal");

app.MapPut("/animals/{id:int}", (IMockDb mockDb, int id, Animal animal) =>
    {
        var animalToEdit = mockDb.GetAnimalById(id);
        if (animalToEdit == null)
        {
            return Results.NotFound();
        }
        
        mockDb.EditAnimal(animalToEdit, animal);
        
        return Results.NoContent();
    }).WithName("EditAnimal");

app.MapDelete("/animals/{id:int}", (IMockDb mockDb, int id) =>
{
    var animal = mockDb.GetAnimalById(id);
    if (animal == null)
    {
        return Results.NoContent();
    }
    
    mockDb.DeleteAnimal(animal);
    return Results.NoContent();    
}).WithName("GetAnimalById");

app.MapPost("/visits", (IMockDb mockDb, Visit visit) =>
{
    mockDb.AddVisit(visit);
    return Results.Created();
}).WithName("AddVisit");

app.MapGet("/visits/{idAnimal:int}", IResult (IMockDb mockDb, int idAnimal) =>
{
    var animal = mockDb.GetAnimalById(idAnimal);
    if (animal == null)
    {
        return Results.NoContent();
    }
    
    var list = mockDb.GetVisitsOf(animal);
    if (list.Count < 1)
    {
        return Results.NotFound();
    }

    return Results.Ok(list);
}).WithName("GetVisitOf");

app.MapControllers();
app.Run();

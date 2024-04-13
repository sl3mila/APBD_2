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
});

app.MapGet("/animals/{id}", (IMockDb mockDb, int id) =>
{
    var animal = mockDb.GetAnimalById(id);
    if (animal is null) return Results.NotFound();
    
    return Results.Ok(animal);
});

app.MapPost("/animals/{id}", (IMockDb mockDb, int id) =>
{
    var animal = mockDb.GetAnimalById(id);
    if (animal is null) return Results.NotFound();
    
    mockDb.AddAnimal(animal);
    return Results.Created();
    
});

//TODO dodać edycje zwierzęcia

app.MapDelete("/animals/{id}", (IMockDb mockDb, int id) =>
{
    var animal = mockDb.GetAnimalById(id);
    if (animal is null) return Results.NotFound();
    
    mockDb.DeleteAnimal(animal);
    return Results.Ok("Deleted");    
});

app.MapPost("/animals", (IMockDb mockDb, Visit visit) =>
{
    mockDb.AddVisit(visit);
    return Results.Created();
});

app.MapGet("/animals/{id}", IResult (IMockDb mockDb, int id) =>
{
    var animal = mockDb.GetAnimalById(id);
    
    var list = mockDb.GetVisitsOf(animal);
    if (list is null) return Results.NotFound();

    return Results.Ok(list);
});

app.MapControllers();
app.Run();

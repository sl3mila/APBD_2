using kolokwium_2.Context;
using kolokwium_2.Exceptions;
using kolokwium_2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICharacterService, CharacterService>();
//builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/characters/{characterId:int}", async (int id, ICharacterService service) =>
{
    try
    {
        return Results.Ok(await service.GetCharacterId(id));
    }
    catch (NotFoundException e)
    {
        return Results.NotFound(e.Message);
    }
});

app.MapPost("/api/character/{characterId:int}/backpackslots", async (int Characteristics, List<int> list, ICharacterService service) =>
{
    /*try
    {
        return Results.Ok(await service.GetCharacterId(id));
    }
    catch (NotFoundException e)
    {
        return Results.NotFound(e.Message);
    }*/
});

app.Run();
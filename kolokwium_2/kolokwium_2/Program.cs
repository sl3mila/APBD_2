using kolokwium_2.Context;
using kolokwium_2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExampleTableClassService, ExampleTableClassService>();
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

/*app.MapGet("/api/accounts/{accountId:int}", async (int id, IAccountService service) =>
{
    try
    {
        return Results.Ok(await service.GetAccountIdAsync(id));
    }
    catch (NotFoundException e)
    {
        return Results.NotFound(e.Message);
    }
});*/

app.Run();
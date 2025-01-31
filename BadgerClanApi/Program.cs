using BadgerClan.Logic;
using BadgerClanApi;
using BadgerClanApi.Pathing;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<PathService>();
builder.Services.AddSingleton<IPath, RunAndGun>();
builder.Services.AddSingleton<IPath, RunAway>();
builder.Services.AddSingleton<IPath, Sacrifice>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var client = new HttpClient();
app.MapGet("/set/{pathing}", ([FromServices] PathService pathService, string pathing) =>
{
    app.Logger.LogInformation($"{pathing} request made");
    pathService.SetPathing(pathing);
    return Results.Ok($"Set to {pathing}.");
});

app.MapPost("/", async ([FromBody] MoveRequest request, [FromServices] PathService pathService) =>
{
    app.Logger.LogInformation($"Turn: {request.TurnNumber}");
    var myMoves = new List<Move>();

    var currentPath = pathService.GetPathing();

    var pathing = pathService.GetPathing();
    var moves = await pathing.GetMovesAsync(request);

    return new MoveResponse(moves);
});

app.Run();

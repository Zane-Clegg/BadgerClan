using BadgerClan.Logic;
using BadgerClan.gRPC.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

string _pathing = "Nothing";
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var client = new HttpClient();

app.MapGet("/", () => "Api running");

app.MapGet("/path", () => _pathing);

app.MapGet("/set/{pathing}", ([FromServices] BadgerClanService BcService, string pathing) =>
{
    _pathing = pathing;
    app.Logger.LogInformation($"{pathing} request made");
    BcService.SetPathing(pathing);
    return Results.Ok($"Set to {pathing}.");
});

app.MapPost("/", async ([FromBody] MoveRequest request, [FromServices] BadgerClanService BcService) =>
{
    app.Logger.LogInformation($"Turn: {request.TurnNumber}");
    var myMoves = new List<Move>();

    var currentPath = BcService.GetPathing();

    var pathing = BcService.GetPathing();
    var moves = await pathing.GetMovesAsync(request);

    return new MoveResponse(moves);
});


app.Run();

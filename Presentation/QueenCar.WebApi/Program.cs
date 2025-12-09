using QueenCar.Application.Features.CQRS.Handlers.AboutHandlers;
using QueenCar.Application.Interfaces;
using QueenCar.Persistence.Context;
using QueenCar.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Db Context
builder.Services.AddScoped<QueenCarContext>();
// Generic Repository
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
// About Handlers
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

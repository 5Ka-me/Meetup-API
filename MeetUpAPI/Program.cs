using API.Models;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using BLL.Validators;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using FluentValidation;
using MeetUpAPI.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IValidator<EventModel>, EventValidator>();

builder.Services.AddAutoMapper(typeof(EventProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

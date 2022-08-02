using DI;
using MeetUpAPI.Middleware;
using MeetUpAPI.Profiles;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services));

builder.Services.AddContext(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddRepositories();

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

app.UseSerilogRequestLogging();

app.UseMiddleware<CustomExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

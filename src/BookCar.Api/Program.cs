using BookCar.Application.DependencyInjection;
using BookCar.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Create services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson()
    .AddApplicationPart(typeof(BookCar.Presentation.AssemblyReference).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureRepository();
builder.Services.AddApplication();


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

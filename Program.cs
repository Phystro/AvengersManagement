global using AvengersManagement.Models;
using AvengersManagement.Data;
using AvengersManagement.Services.AvengerService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// register the service
builder.Services.AddScoped<IAvengerService, AvengerService>();
builder.Services.AddDbContext<AvengerContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("AvengerContext"));
} );

var app = builder.Build();

// Create database
// using IServiceScope scope = app.Services.CreateScope();
// AvengerContext context = scope.ServiceProvider.GetRequiredService<AvengerContext>();
// await context.Database.EnsureCreatedAsync();

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

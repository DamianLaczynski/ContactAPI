using ContactAPI;
using ContactAPI.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ContactsDbContext>();
builder.Services.AddScoped<ContactSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.

using (var scope = app.Services.CreateScope())
{
    var contactSeeder = scope.ServiceProvider.GetService<ContactSeeder>();
    contactSeeder.Seed();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

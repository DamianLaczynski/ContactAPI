using ContactAPI;
using ContactAPI.Controllers;
using ContactAPI.Entities;
using ContactAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddTransient<IContactService, ContactController>();
builder.Services.AddControllers();
builder.Services.AddDbContext<ContactsDbContext>();
builder.Services.AddScoped<ContactSeeder>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IContactService, ContactService>();

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

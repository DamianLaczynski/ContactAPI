using ContactAPI;
using ContactAPI.Controllers;
using ContactAPI.Entities;
using ContactAPI.Models;
using ContactAPI.Services;
using ContactAPI.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddTransient<IContactService, ContactController>();
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddDbContext<ContactsDbContext>();
builder.Services.AddScoped<ContactSeeder>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPasswordHasher<Contact>, PasswordHasher<Contact>>();
builder.Services.AddScoped<IValidator<RegisterContactDto>, RegisterContactDtoValidator>();
builder.Services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

using (var scope = app.Services.CreateScope())
{
    var contactSeeder = scope.ServiceProvider.GetService<ContactSeeder>();
    contactSeeder.Seed();
}

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact API");
});

app.UseAuthorization();

app.MapControllers();

app.Run();

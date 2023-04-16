using ContactAPI;
using ContactAPI.Controllers;
using ContactAPI.Entities;
using ContactAPI.Models;
using ContactAPI.Services;
using ContactAPI.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var authenticationSetting = new AuthenticationSettings();

// dodawanie serwisów do obs³ugi tworzenia tokenów 
builder.Configuration.GetSection("Authentication").Bind(authenticationSetting);
builder.Services.AddSingleton(authenticationSetting);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultAuthenticateScheme = "Bearer";

}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = authenticationSetting.JwtIssuer,
        ValidAudience = authenticationSetting.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSetting.JwtKey))
    };

});


//Dodanie kontrolerów i obs³ugi walidacji modeli
builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddDbContext<ContactsDbContext>();

builder.Services.AddScoped<ContactSeeder>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IPasswordHasher<Contact>, PasswordHasher<Contact>>();

//dodanie walidatorów
builder.Services.AddScoped<IValidator<RegisterContactDto>, RegisterContactDtoValidator>();
builder.Services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateContactDto>, UpdateContactDtoValidator>();

builder.Services.AddSwaggerGen(); //Dodanie Swaggera do generowania dokumentacji

builder.Services.AddCors(setup =>
{
    setup.AddPolicy("default", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

using (var scope = app.Services.CreateScope())
{
    var contactSeeder = scope.ServiceProvider.GetService<ContactSeeder>();
    contactSeeder.Seed();
}

app.UseAuthentication();
app.UseHttpsRedirection();

//u¿ycie biblioteki Swagger do generowania dokumentacji z interaktywnymi przyk³adami
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact API");
});

app.UseCors("default");

app.UseAuthorization();

app.MapControllers();

app.Run();

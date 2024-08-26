using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using AdvisorManagementApi.MappingProfiles;
using ApexaTechnicalApi.Data;
using ApexaTechnicalApi.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Adding services to the container
builder.Services.AddControllers();

// Configuring the in-memory database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("AdvisorManagementDb"));

// Configuring AutoMapper with multiples profiles
builder.Services.AddAutoMapper(typeof(AdvisorMappingProfile), typeof(UserMappingProfile));



//Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registering custom services
builder.Services.AddScoped<ApexaTechnicalApi.Services.AdvisorService>();

var app = builder.Build();

// Configuring the HTTP pipelines
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();

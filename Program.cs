using Microsoft.EntityFrameworkCore;
using StudentRegistrationForm.Data;
using StudentRegistrationForm.Interfaces;
using StudentRegistrationForm.Interfaces.ServiceInterface;
using StudentRegistrationForm.Services;
using StudentRegistrationForm.UnitOfWork;
using FluentValidation;
using FluentValidation.AspNetCore;
using StudentRegistrationForm.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ? Register UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ? Register StudentService
builder.Services.AddScoped<IStudentService, StudentService>();

// ? Register FileService
builder.Services.AddScoped<IFileService, FileService>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// ? ADD FLUENTVALIDATION
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CompleteRequestDTOValidator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
using Microsoft.EntityFrameworkCore;
using StudentRegistrationForm.Data;
using StudentRegistrationForm.Interfaces;
using StudentRegistrationForm.Interfaces.ServiceInterface;
using StudentRegistrationForm.Services;
using StudentRegistrationForm.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ? Register UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ? Register StudentService (ADDED)
builder.Services.AddScoped<IStudentService, StudentService>();

// ? Register FileService (NEW)
builder.Services.AddScoped<IFileService, FileService>();

// Add this line with your other service registrations
builder.Services.AddAutoMapper(typeof(Program));

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

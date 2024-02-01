using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication1;
using WebApplication1.Services.StudentService;
using WebApplication1.Services.StudentSubjectService;
using WebApplication1.Services.SubjectService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add Application Db Context
builder.Services.AddDbContext<ApplicationDbContext>(Options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    Options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// register custom services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IStudentSubjectService, StudentSubjectService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

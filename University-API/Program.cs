using AutoMapper;
using Microsoft.EntityFrameworkCore;
using University_API.Data;
using University_API.Helpers;
using University_API.Repositories;
using University_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UniversityContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UniversityConnection")));

builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();

builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });

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

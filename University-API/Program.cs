using AutoMapper;
using Microsoft.EntityFrameworkCore;
using University_API.Data;
using University_API.Helpers;
using University_API.Repositories;
using University_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UniversityContext>(options =>
    options
    .UseLazyLoadingProxies()
    .UseNpgsql(builder.Configuration.GetConnectionString("UniversityConnection")));

builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<IHorarioTurmaRepository, HorarioTurmaRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();

builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IDisciplinaService, DisciplinaService>();
builder.Services.AddScoped<ITurmaService, TurmaService>();
builder.Services.AddScoped<IHorarioTurmaService, HorarioTurmaService>();
builder.Services.AddScoped<IAlunoService, AlunoService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
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

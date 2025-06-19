using SistemaAcademico.Data;
using SistemaAcademico.EndPoints;
using SistemaAcademico.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddDbContext<AcademicoContext>();
builder.Services.AddTransient<DAL<Aluno>>();
builder.Services.AddTransient<DAL<Curso>>();
builder.Services.AddTransient<DAL<Disciplina>>();
builder.Services.AddTransient<DAL<Matricula>>();
builder.Services.AddTransient<DAL<Nota>>();
builder.Services.AddTransient<DAL<Professor>>();
builder.Services.AddTransient<DAL<Turma>>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");
app.AddEndPointsAluno();
app.AddEndPointsCurso();
app.AddEndPointsDisciplina();
app.AddEndPointsMatricula();
app.AddEndPointsNota();
app.AddEndPointsProfessor();
app.AddEndPointsTurma();
app.AddEndPointsHorario();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); 

app.Run();

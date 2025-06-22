using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Data;
using SistemaAcademico.EndPoints;
using SistemaAcademico.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// ✅ Configuração CORS corrigida (permite cookies)
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("https://localhost:7181") // substitua por sua URL do cliente
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials(); // <- IMPORTANTE
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
builder.Services.AddTransient<DAL<Frequencia>>();
builder.Services.AddTransient<DAL<Financeiro>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services
    .AddIdentityApiEndpoints<PessoaComAcesso>()
    .AddEntityFrameworkStores<AcademicoContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ UseCors DEVE vir antes dos endpoints e antes da autenticação
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.AddEndPointsAluno();
app.AddEndPointsCurso();
app.AddEndPointsDisciplina();
app.AddEndPointsMatricula();
app.AddEndPointsNota();
app.AddEndPointsProfessor();
app.AddEndPointsTurma();
app.AddEndPointsHorario();
app.AddEndPointsFrequencia();
app.AddEndPointsFinanceiro();
app.AddEndPointsRelatorio();
app.AddEndPointsRelatorioTurmaDisciplina();
app.AddEndPointsRelatorioStatusMatricula();

app.MapGroup("auth").MapIdentityApi<PessoaComAcesso>().WithTags("Autorização");

app.MapPost("auth/logout", async ([FromServices] SignInManager<PessoaComAcesso> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok();
}).RequireAuthorization().WithTags("Autorização");

app.Run();

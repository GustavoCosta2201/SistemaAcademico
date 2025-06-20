using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.Models;
using SistemaAcademico.Data;
using SistemaAcademico.Models;
using SistemaAcademico.Request;

namespace SistemaAcademico.EndPoints
{
    public static class FrequenciaExtension
    {
        public static void AddEndPointsFrequencia(this WebApplication app)
        {
            var GroupBuilder = app.MapGroup("Frequencia").WithTags("Frequencia");

            GroupBuilder.MapGet("", ([FromServices] DAL<Frequencia> frequencia) =>
            {
                var frequencias = frequencia.GetAll();
                return Results.Ok(frequencias);
            });

            GroupBuilder.MapGet("{id:int}", ([FromServices] DAL<Frequencia> frequencia, int id) =>
            {
                var freqRecover = frequencia.GetItem(f => f.Id_Frequencia == id);
                return freqRecover is not null ? Results.Ok(freqRecover) : Results.NotFound();
            });

            GroupBuilder.MapPost("", ([FromServices] DAL<Frequencia> frequencia, [FromBody] FrequenciaRequest freqRequest) =>
            {
                var freqNew = new Frequencia(
                    freqRequest.Id_Matricula,
                    freqRequest.Data_Frequencia,
                    freqRequest.Presenca
                );
                frequencia.AddItem(freqNew);
                return Results.Ok(freqNew);
            });

            GroupBuilder.MapPut("/{id:int}", ([FromServices] DAL<Frequencia> frequencia, int id, FrequenciaEdit edit) =>
            {
                var freqRecover = frequencia.GetItem(f => f.Id_Frequencia == id);

                if (freqRecover != null)
                {
                    freqRecover.Id_Matricula = edit.Id_Matricula;
                    freqRecover.Data_Frequencia = edit.Data_Frequencia;
                    freqRecover.Presenca = edit.Presenca;

                    frequencia.UpdateItem(freqRecover);
                    return Results.Ok(freqRecover);
                }
                else
                {
                    return Results.NotFound();
                }
            });

            GroupBuilder.MapDelete("{id:int}", ([FromServices] DAL<Frequencia> frequencia, int id) =>
            {
                var freqDelete = frequencia.GetItem(f => f.Id_Frequencia == id);
                frequencia.RemoveItem(freqDelete);
                return Results.NoContent();
            });
        }
    }
}

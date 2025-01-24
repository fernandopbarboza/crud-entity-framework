using Dados;
using Microsoft.EntityFrameworkCore;

namespace api_crud_entity_framework.Estudantes
{
    public static class EstudantesRotas
    {
        public static void AddRotasEstudantes (this WebApplication app) {

            var rotasEstudantes = app.MapGroup(prefix:"estudantes");

            // Adicionando estudante
            rotasEstudantes.MapPost("", async (AddEstudanteRequest request, AppDbContext context, CancellationToken ct) => {
                
                var existe = await context.Estudantes.AnyAsync(e => e.Nome == request.Nome, ct);

                if (existe) {
                    return Results.Conflict("Estudante já cadastrado");
                }

                var estudante = new Estudante(request.Nome);
                await context.Estudantes.AddAsync(estudante, ct);
                await context.SaveChangesAsync(ct);

                var estudanteRetorno = new EstudanteDto(estudante.Id, estudante.Nome);

                return Results.Ok(estudanteRetorno);
                
            });

            // Retornar todos estudantes
            rotasEstudantes.MapGet("", async (AppDbContext context,CancellationToken ct) => {
                var estudantes = await context.Estudantes
                .Where(estudante => estudante.Ativo)
                .Select(estudante => new EstudanteDto(estudante.Id, estudante.Nome))
                .ToListAsync(ct);

                return Results.Ok(estudantes);
            });

            //Atualizar Nome do estudante
            rotasEstudantes.MapPut("{id}", async (Guid id, UpdateEstudanteRequest request, AppDbContext context,CancellationToken ct) => {
                var estudante = await context.Estudantes.FindAsync(id,ct);

                if (estudante == null) {
                    return Results.NotFound();
                }

                estudante.AtualizarNome(request.Nome);
                await context.SaveChangesAsync(ct);                

                return Results.Ok(new EstudanteDto(estudante.Id, estudante.Nome));
            });

            //"Deletar" - Desativar estudante
            rotasEstudantes.MapDelete("{id}", async (Guid id, AppDbContext context,CancellationToken ct) => {
                var estudante = await context.Estudantes.FindAsync(id,ct);

                if (estudante == null) {
                    return Results.NotFound();
                }

                estudante.Desativar();
                await context.SaveChangesAsync(ct);

                return Results.NoContent();
            });

        }
    }
}

 
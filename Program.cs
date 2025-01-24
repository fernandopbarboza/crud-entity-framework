using Dados;
using api_crud_entity_framework.Estudantes;

var builder = WebApplication.CreateBuilder(args);

/* 
===============================================================================================
== Documentação oficial:
== https://learn.microsoft.com/pt-br/ef/core/cli/dotnet

== Video de referencia:
== https://www.youtube.com/watch?v=b7OoeiG_BzU
== Playlist de referencia:
=== https://www.youtube.com/playlist?list=PLMFE0Mu3BVy5KeaTk0eGOXPOxyl1yIxOA

== Demais conteúdos
https://www.youtube.com/playlist?list=PL85ITvJ7FLohEWHrA1tU1Rijd-6Br_huQ
https://www.youtube.com/watch?v=bnAuqSgmTyc
 ===============================================================================================
 */
 
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Configurando as rotas
app.AddRotasEstudantes();

app.Run();
namespace api_crud_entity_framework.Estudantes
{
    public class Estudante
    {
        public Guid Id { get; init; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        public Estudante(string nome){
            Id = Guid.NewGuid();
            Nome = nome;
            Ativo = true;
        }

        public void AtualizarNome(string nome){
            Nome = nome;
        }

        public void Desativar(){
            Ativo = false;
        }
    }
    
}
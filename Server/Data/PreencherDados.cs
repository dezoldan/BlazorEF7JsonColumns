using BlazorAppJsonColumns.Shared;

namespace BlazorAppJsonColumns.Server.Data
{
    public class PreencherDados
    {
       public static void Preencher()
        {
            using var context = new DataContext();
            var NovoAluno = new Aluno
            {
                Nome = "Aluno1",
                Sobrenome = "Estudioso",
                Details = new AlunoDetails()
                {
                    Idade = 18,
                    Rua = "Fantasia",
                    Cidade = "Alegria"
                }
            };
            context.Add(NovoAluno);
            context.SaveChanges();
        }
    }
}

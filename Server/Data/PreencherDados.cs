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
                Nome = "Daniel",
                Sobrenome = "Zoldan",
                Details = new AlunoDetails()
                {
                    Idade = 46,
                    Rua = "Das Flores",
                    Cidade = "Porto Alegre"
                }
            };
            context.Add(NovoAluno);
            context.SaveChanges();
        }
    }
}

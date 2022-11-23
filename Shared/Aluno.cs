using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppJsonColumns.Shared
{
    [Table("TblTeste2")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;        
        public AlunoDetails? Details { get; set; }
        
        [NotMapped]
        public bool IsRowExpanded { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Livraria.Models
{
    public class LeitorModel
    {
        [Key]
        public int LeitorId { get; set; }

        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }

        ICollection<EmprestimosMdel> Emprestimos{ get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Models
{
    
    public class StatusModel
    {
        [Key]
        public int StatusId { get; set; }
        public string Status { get; set; }
     

        ICollection<EmprestimosMdel> Emprestimo { get; set; }

    }
}

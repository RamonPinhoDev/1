using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Models
{
   
    public class EmprestimosMdel
    {
        [Key]
        public int EmprestimoId { get; set; }
 
        
        public string LivroEmprestado { get; set; }
        public DateTime dataRetirada { get; set; }
        public DateTime dataEntrega{ get; set; } 

        public int StatusId { get; set; }
        public StatusModel  Status { get; set; }

        public int LeitorId { get; set; }

        public LeitorModel Leitor { get; set; }

    }
}
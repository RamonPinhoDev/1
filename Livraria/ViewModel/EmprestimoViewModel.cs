using Livraria.Models;

namespace Livraria.ViewModel
{
    public class EmprestimoViewModel
    {
        public int EmprestimoId { get; set; }
        public string LivroEmprestado { get; set; }
        public DateTime dataRetirada { get; set; }
        public DateTime dataEntrega { get; set; }

        public int StatusId { get; set; }
        public string? Status { get; set; }

        public int LeitorId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }

    }
}

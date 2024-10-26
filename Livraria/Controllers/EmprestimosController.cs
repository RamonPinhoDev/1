

using Livraria.Data;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;
using Livraria.ViewModel;
using System;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Livraria.Controllers
{
    public class EmprestimosController : Controller
    {
        readonly private ApplicationDbContext _db;
        private readonly int novoId;
       
        public EmprestimosController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {

           


            IEnumerable<EmprestimoViewModel> emprestimos = _db.Emprestimos.Include(e => e.Status).Include(e => e.Leitor)
                .Select(e => new EmprestimoViewModel
                {
                    EmprestimoId = e.EmprestimoId,
                    LivroEmprestado = e.LivroEmprestado,
                    dataRetirada = e.dataRetirada,
                    dataEntrega = e.dataEntrega,
                    //StatusId = e.StatusId,  
                    Status = e.Status.Status,
                    //LeitorId = e.LeitorId,
                    Nome = e.Leitor.Nome,
                    Idade = e.Leitor.Idade,
                    Sexo = e.Leitor.Sexo

                  




                }).ToList();



           // ViewBag.Status = _db.Status.FirstOrDefault(c => c.StatusId == 1);
           // ViewBag.Leitores = _db.Leitores.ToList();


            return View(emprestimos);
        }

        public IActionResult Csv(EmprestimoViewModel emp)
        {
            
            IEnumerable<EmprestimoViewModel> emprestimos = _db.Emprestimos.Include(e => e.Status).Include(e => e.Leitor)
                .Select(e => new EmprestimoViewModel
                {
                    EmprestimoId = e.EmprestimoId,
                    LivroEmprestado = e.LivroEmprestado,
                    dataRetirada = e.dataRetirada,
                    dataEntrega = e.dataEntrega,
                    Status = e.Status.Status,
                    Nome = e.Leitor.Nome,
                    Idade = e.Leitor.Idade,
                    Sexo = e.Leitor.Sexo

                }).ToList();
            var livro = emp.LivroEmprestado;
            var dataRet = emp.dataRetirada;
            var dataEn = emp.dataEntrega;
            var status = emp.Status;
            var nome = emp.Nome;
            var idade = emp.Idade;
            var sexo = emp.Sexo;
            // Conteúdo do CSV
            var csvContent = new StringBuilder();
            csvContent.AppendLine("Livro Emprestado,Data Retirada,Data Entrega,Status,Nome,Idade,Sexo");
            foreach (var emprestimo in emprestimos)
    {
        csvContent.AppendLine($"{emprestimo.LivroEmprestado},{emprestimo.dataRetirada},{emprestimo.dataEntrega},{emprestimo.Status},{emprestimo.Nome},{emprestimo.Idade},{emprestimo.Sexo}");
    }

            var filePath = @"C:\Users\Ideapad 3i\Documents\Udemy\Projetos C# O\Machine_learning\ML_Uninassau\emprestimo.csv";

            try
            {
                System.IO.File.WriteAllText(filePath, csvContent.ToString());

                
                return View(Csv);
            }
            catch (Exception ex)
            {         
                return BadRequest($"Erro ao salvar o arquivo: {ex.Message}");
            }
        }




        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Leitores = new SelectList(_db.Leitores.ToList(), "LeitorId", "Nome");
            ViewBag.Status = new SelectList(_db.Status.ToList(), "StatusId", "Status");

            return View();
            
        }



        [HttpGet]
        public IActionResult Editar(int? id)
        {
            ViewBag.Status = new SelectList(_db.Status.ToList(), "StatusId", "Status");
            ViewBag.Leitores = new SelectList(_db.Leitores.ToList(), "LeitorId", "Nome");
            if (id == null || id == 0)
            {
                return NotFound();

            }

            EmprestimosMdel emprestimo = _db.Emprestimos.Include(c => c.Leitor).Include(c => c.Status).FirstOrDefault(x => x.EmprestimoId == id);
            var emprestimoEditado = new EmprestimosMdel()
            {
                dataRetirada = emprestimo.dataRetirada,
                dataEntrega = emprestimo.dataEntrega,
                Status = emprestimo.Status,
                Leitor = emprestimo.Leitor,
                
                LivroEmprestado = emprestimo.LivroEmprestado

            };
            if (emprestimo == null)
            {
                return NotFound();
            }


            return View(emprestimoEditado);
        }

        [HttpGet]
        public IActionResult CadastrarLeitor()
        {
            return View ();
        }

        [HttpPost]
        public IActionResult CadastrarLeitor(LeitorModel leitor)
        {
            if (ModelState.IsValid)
            {
                var leitorCadastrado = new LeitorModel()
                {
                    Nome = leitor.Nome,
                    Idade = leitor.Idade,
                    Sexo = leitor.Sexo
                };



                _db.Leitores.Add(leitorCadastrado);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leitor);


            
        }


        [HttpPost]
        public IActionResult Cadastrar(EmprestimosMdel emprestimo)
        {
            

                _db.Emprestimos.Add(emprestimo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            


        }


        [HttpPost]
        public IActionResult Editar(EmprestimosMdel emprestimoEditado, int Id)
        {

            var emprestimoExistente = _db.Emprestimos.Find(Id);

            emprestimoExistente.dataRetirada = emprestimoEditado.dataRetirada;
            emprestimoExistente.dataEntrega = emprestimoEditado.dataEntrega;
            emprestimoExistente.LivroEmprestado = emprestimoEditado.LivroEmprestado;
            emprestimoExistente.StatusId = emprestimoEditado.StatusId;
            emprestimoExistente.LeitorId = emprestimoEditado.LeitorId;
            

            _db.SaveChanges();
            return RedirectToAction("Index");
           
        }

        [HttpGet]

        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var emprestimo = _db.Emprestimos.Include(c => c.Leitor).Include(c => c.Status).FirstOrDefault(x => x.EmprestimoId == id);
            var empretimoEcluido = new EmprestimoViewModel()
            {
                dataEntrega = emprestimo.dataEntrega,
                dataRetirada = emprestimo.dataRetirada,
                Status = emprestimo.Status.Status,
                LivroEmprestado = emprestimo.LivroEmprestado,
                Idade = emprestimo.Leitor.Idade,
                Nome = emprestimo.Leitor.Nome,
                Sexo = emprestimo.Leitor.Sexo,

            };


            return View(empretimoEcluido);

        }

        [HttpPost]
        public IActionResult Excluir(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var emprestimos = _db.Emprestimos.Include(c => c.Status).Include(c => c.Leitor).FirstOrDefault(x => x.EmprestimoId == Id);


            _db.Emprestimos.Remove(emprestimos);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}


using Livraria.Data;
using Livraria.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace Livraria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {

            _context = context;
            _logger = logger;

        }

        public IActionResult Index()
        {
          ViewBag.Total= _context.Emprestimos.ToList().Count();
            var emprestimos = _context.Emprestimos.Where(e => e.StatusId == 1).ToList();
            var empre = emprestimos.Count();

            ViewBag.Emprestado = empre; // Atribuindo valor no Index()
            var disponivel = _context.Emprestimos.Where(e => e.StatusId == 2).ToList();
            var dispo = disponivel.Count();

            ViewBag.Disponivel = dispo;

            var Naodevolvido = _context.Emprestimos.Where(e => e.StatusId == 3).ToList();
            var naoDevolv = Naodevolvido.Count();
            ViewBag.NaoDevolvido = naoDevolv;

            var generoM = _context.Emprestimos.Where(e => e.Leitor.Sexo == 'M').ToList();
            var genM = generoM.Count();

            ViewBag.GeneroM = genM;

            var generoF = _context.Emprestimos.Where(e => e.Leitor.Sexo == 'F').ToList();
            var genF = generoF.Count();

            ViewBag.GeneroF = genF;
            //janeiro
            int qtMes = 0;
            var DataInicialJan = _context.Emprestimos.Where(c => c.dataRetirada >= new DateTime(2023, 01, 01) &&
               c.dataRetirada <= new DateTime(2023, 01, 30)).ToList();

            qtMes = DataInicialJan.Count();
            ViewBag.MesesJan = qtMes;
            //fevereiro
            qtMes = 0;
            var DataInicialFev = _context.Emprestimos.Where(c => c.dataRetirada >= new DateTime(2023, 02, 01) &&
               c.dataRetirada <= new DateTime(2023, 02, 28)).ToList();

            qtMes = DataInicialFev.Count();
            ViewBag.MesesFev = qtMes;

            //Março
            qtMes = 0;
            var DataInicialMar = _context.Emprestimos.Where(c => c.dataRetirada >= new DateTime(2023, 03, 01) &&
               c.dataRetirada <= new DateTime(2023, 03, 30)).ToList();

            qtMes = DataInicialMar.Count();
            ViewBag.MesesMar = qtMes;

            //Abril
            qtMes = 0;
            var DataInicialAbr = _context.Emprestimos.Where(c => c.dataRetirada >= new DateTime(2023, 04, 01) &&
               c.dataRetirada <= new DateTime(2023, 04, 30)).ToList();

            qtMes = DataInicialAbr.Count();
            ViewBag.MesesAbr = qtMes;

            //Maio
            qtMes = 0;
            var DataInicialMai = _context.Emprestimos.Where(c => c.dataRetirada >= new DateTime(2023, 05, 01) &&
               c.dataRetirada <= new DateTime(2023, 05, 30)).ToList();

            qtMes = DataInicialMai.Count();
            ViewBag.MesesMai = qtMes;

            //Jun
            qtMes = 0;
            var DataInicialJun = _context.Emprestimos.Where(c => c.dataRetirada >= new DateTime(2023, 06, 01) &&
               c.dataRetirada <= new DateTime(2023, 06, 30)).ToList();

            qtMes = DataInicialJun.Count();
            ViewBag.MesesJun = qtMes;

            //Jul
            qtMes = 0;
            var DataInicialJul = _context.Emprestimos.Where(c => c.dataRetirada >= new DateTime(2023, 07, 01) &&
               c.dataRetirada <= new DateTime(2023, 07, 30)).ToList();

            qtMes = DataInicialJul.Count();
            ViewBag.MesesJul = qtMes;

            //Ago
            qtMes = 0;
            var DataInicialAgo = _context.Emprestimos.Where(c => c.dataRetirada >= new DateTime(2023, 08, 01) &&
               c.dataRetirada <= new DateTime(2023, 08, 30)).ToList();

            qtMes = DataInicialAgo.Count();
            ViewBag.MesesAgo = qtMes;

            //Set
            qtMes = 0;
            var DataInicialSet = _context.Emprestimos.Where(c => c.dataRetirada >= new DateTime(2023, 09, 01) &&
               c.dataRetirada <= new DateTime(2023, 09, 30)).ToList();

            qtMes = DataInicialSet.Count();
            ViewBag.MesesSet = qtMes;

            //Out
            qtMes = 0;
            var DataInicialOut = _context.Emprestimos.Where(c => c.dataRetirada >= new DateTime(2023, 10, 01) &&
               c.dataRetirada <= new DateTime(2023, 10, 30)).ToList();

            qtMes = DataInicialOut.Count();
            ViewBag.MesesOut = qtMes;

            //Nov
            qtMes = 0;
            var DataInicialNov = _context.Emprestimos.Where(c => c.dataRetirada >= new DateTime(2023, 11, 01) &&
               c.dataRetirada <= new DateTime(2023, 11, 30)).ToList();

            qtMes = DataInicialNov.Count();
            ViewBag.MesesNov = qtMes;

            //Dez
            qtMes = 0;
            var DataInicialDez = _context.Emprestimos.Where(c => c.dataRetirada >= new DateTime(2023, 12, 01) &&
               c.dataRetirada <= new DateTime(2023, 12, 31)).ToList();

            qtMes = DataInicialDez.Count();
            ViewBag.MesesDez = qtMes;


            return View();
        }

        private object Select()
        {
            throw new NotImplementedException();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
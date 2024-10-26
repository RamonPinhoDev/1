using Livraria.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<EmprestimosMdel> Emprestimos { get; set; }

        public DbSet<StatusModel> Status { get; set; }
        public DbSet<LeitorModel> Leitores { get; set; }
        

    }
}

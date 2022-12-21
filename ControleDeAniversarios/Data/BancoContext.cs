using ControleDeAniversarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeAniversarios.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {


        }

        public DbSet<AniversarianteModel> Aniversariante { get; set; }
    }
}

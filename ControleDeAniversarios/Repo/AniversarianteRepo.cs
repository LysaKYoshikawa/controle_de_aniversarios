using ControleDeAniversarios.Data;
using ControleDeAniversarios.Models;

namespace ControleDeAniversarios.Repo
{
    public class AniversarianteRepo : IAniversarianteRepo
    {
        private readonly BancoContext bancoContext1;
        public AniversarianteRepo(BancoContext bancoContext)
        {
            bancoContext1 = bancoContext;
        }
        public AniversarianteModel Adicionar(AniversarianteModel aniversariante)
        {
            // grvas no bd
            bancoContext1.Aniversariante.Add(aniversariante);
            bancoContext1.SaveChanges(); 
            return aniversariante;
        }
    }
}

using ControleDeAniversarios.Models;

namespace ControleDeAniversarios.Repo
{
    public interface IAniversarianteRepo
    {
        AniversarianteModel Adicionar(AniversarianteModel aniversariante);
    }
}

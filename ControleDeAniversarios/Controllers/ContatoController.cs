using ControleDeAniversarios.Models;
using ControleDeAniversarios.Repo;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeAniversarios.Controllers
{
    public class ContatoController : Controller
    {
        public ContatoController(IAniversarianteRepo aniversariantesRepo) {

            aniversariantesRepo = AniversarianteRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        public IActionResult Criar(AniversarianteModel aniversariante)
        {
            aniversariantesRepo.Adicionar(aniversariante);
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;

namespace RolêTopMVC.Controllers
{
    public class AmbienteController : AbstractController
    {
        public IActionResult Index()
        {
            return View(new AgendamentoViewModel()
            {
                NomeView = "Ambiente",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
    }
}
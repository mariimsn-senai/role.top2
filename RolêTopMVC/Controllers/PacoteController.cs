using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;
using RolêTopMVC.ViewModels;

namespace RolêTopMVC.Controllers
{
    public class PacoteController : AbstractController
    {
        public IActionResult Index()
        {
            return View(new PacoteViewModel()
            {
                NomeView = "Pacote",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        

    }
}
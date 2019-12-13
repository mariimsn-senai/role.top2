using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;

namespace RolêTopMVC.Controllers
{
    public class FAQController : AbstractController
    {

        public IActionResult Index()
        {    
                return View(new AgendamentoViewModel(){
                NomeView = "FAQ",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession() 
            });
        }
    }
}
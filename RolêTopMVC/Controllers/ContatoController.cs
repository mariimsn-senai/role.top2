using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;

namespace RolêTopMVC.Controllers
{
    public class ContatoController : AbstractController
    {
        

        public IActionResult Index()
        {    
                return View(new AgendamentoViewModel(){
                NomeView = "Contato",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession() 
            });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;

namespace RolêTopMVC.Controllers
{
    public class CasaController : AbstractController
    {
                public IActionResult Index()
        {    
                return View(new AgendamentoViewModel(){
                NomeView = "Casa",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession() 
            });
        }
    }
}
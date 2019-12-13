using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;
using RolêTopMVC.ViewModels;

namespace RolêTopMVC.Controllers
{
    public class SucessoController : AbstractController
    {

            public IActionResult Index()
        {    
                return View(new RespostasViewModel(){
                NomeView = "Sucesso",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession() 
            });
        }
    }
}
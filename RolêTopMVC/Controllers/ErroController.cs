using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.ViewModels;

namespace RolêTopMVC.Controllers
{
    public class ErroController : AbstractController
    {
        
        public IActionResult Index()
        {
            return View(new RespostasViewModel (){
                NomeView = "Erro"
            });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;
using RolêTopMVC.ViewModels;

namespace RolêTopMVC.Controllers
{
    public class SucessoController : Controller
    {

        public IActionResult Index()
        {
            return View(new RespostasViewModel (){
                NomeView = "Sucesso"
            });
        }
    }
}
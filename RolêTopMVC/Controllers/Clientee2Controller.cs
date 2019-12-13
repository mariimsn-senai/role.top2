using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;
using RolêTopMVC.ViewModels;

namespace RolêTopMVC.Controllers
{
    public class Clientee2Controller : Controller
    {
        public IActionResult Historico()
        {
            return View(new HistoricoViewModel (){
                NomeView = "Cliente"
            });
        }
    }
}
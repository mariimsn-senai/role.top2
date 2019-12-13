using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;

namespace RolêTopMVC.Controllers
{
    public class CasaController : Controller
    {
                public IActionResult Index()
        {
            return View(new AgendamentoViewModel (){
                NomeView = "Casa"
            });
        }
    }
}
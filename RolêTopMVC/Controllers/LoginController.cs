using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;

namespace RolêTopMVC.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View(new AgendamentoViewModel (){
                NomeView = "Login"
            });
        }
    }
}
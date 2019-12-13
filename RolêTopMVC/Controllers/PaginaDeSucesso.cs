using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;

namespace RolêTopMVC.Controllers
{
    public class PaginaDeSucesso : AbstractController
    {
        
        public IActionResult Index()
        {
            return View(new AgendamentoViewModel (){
                NomeView = "PaginaDeSucesso"
            });
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;
using RolêTopMVC.ViewModels;
using RolêTopMVC.Enums;

namespace RolêTopMVC.Controllers
{
    public class AgendamentoController : AbstractController
    {
        public IActionResult Index(AgendamentoViewModel agendamentoViewModel)
        {
            System.Console.WriteLine("====================================================");
            System.Console.WriteLine("Valor do Código do pacote em AgendamentoViewModel (index): ");
            System.Console.WriteLine(agendamentoViewModel.CodigoPacote);
            System.Console.WriteLine("====================================================");
            agendamentoViewModel.UsuarioEmail = ObterUsuarioSession();
            agendamentoViewModel.NomeView = "Agendamento";
            agendamentoViewModel.UsuarioNome = ObterUsuarioNomeSession();
            return View(agendamentoViewModel);
        }

        public IActionResult GravarEvento(IFormCollection form)
        {
            //var id = uint.Parse(form["id_pacote"]);
            //if(id == ValorPacotes.PacoteSimples){

            //}
            AgendamentoViewModel agendamentoViewModel = new AgendamentoViewModel();
            Agendamento agendamento = new Agendamento(
                form["data"],
                form["horario"]
            );
            agendamentoViewModel.data = agendamento.data;
            agendamentoViewModel.horario = agendamento.horario;
            agendamentoViewModel.UsuarioNome = agendamento.Cliente.Nome;

            agendamentoViewModel.CodigoPacote = int.Parse(form["id_pacote"]);
            return RedirectToAction("Index", "Pagamento", agendamentoViewModel);
        }
    }
}
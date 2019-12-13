using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;
using RolêTopMVC.Repositorio;
using RolêTopMVC.ViewModels;

namespace RolêTopMVC.Controllers
{
    public class Clientee2Controller : AbstractController
    {
    private ClienteRepository clienteRepository = new ClienteRepository();
        ProdutoRepository produtoRepository = new ProdutoRepository();
        public IActionResult Historico ()
        {
            var emailCliente = ObterUsuarioSession();
            var pedidosCliente = produtoRepository.ObterTodosPorCliente(emailCliente);

            return View(new HistoricoViewModel()
            {
                Produto = pedidosCliente,
                NomeView = "Historico",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
    }
}
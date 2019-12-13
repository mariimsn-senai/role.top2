using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Enums;
using RolêTopMVC.Models;
using RolêTopMVC.Repositorio;
using RolêTopMVC.ViewModels;

namespace RolêTopMVC.Controllers
{
    public class AdmController : AbstractController
    {
        ProdutoRepository ProdutoRepository = new ProdutoRepository();
        public IActionResult Index()
        {
        
            var ninguemLogdado = string.IsNullOrEmpty(ObterUsuarioTipoSession());
            
            if (!ninguemLogdado || (uint) TiposUsuario.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession()))
            {

            var produtos = ProdutoRepository.ObterTodos();
            DashboardViewModel dashbordViewModel = new DashboardViewModel();

            foreach ( var produto in produtos)
            {
                switch(produto.Status)
                {
                    case (uint) StatusPedido.APROVAR:
                        dashbordViewModel.Aceitar++;
                    break;

                    case
                        (uint) StatusPedido.RECUSAR:
                        dashbordViewModel.Recusar++;
                        // //deixar na lista de pedido pendente
                    break;
                    default:
                        dashbordViewModel.Pendente++;
                        dashbordViewModel.Produto.Add(produto);
                        //deixar na lista de pedido pendente
                    break;
                }
            }
            dashbordViewModel.NomeView = "ADM";
            dashbordViewModel.UsuarioEmail = ObterUsuarioSession();
            dashbordViewModel.Produto = produtos;
            return View(dashbordViewModel);
            }
            else
            {
                return View ("Erro", new RespostasViewModel(){
                NomeView = "ADM",
                Mensagem = "Você não tem permissão para acessar o Dashboard"

                });
            }
        }
    }
}
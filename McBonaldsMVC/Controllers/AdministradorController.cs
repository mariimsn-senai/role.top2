using McBonaldsMVC.Enums;
using McBonaldsMVC.Repositories;
using McBonaldsMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace McBonaldsMVC.Controllers
{
    public class AdministradorController : AbstractController
    {
        PedidoRepository pedidoRepository = new PedidoRepository();
        public IActionResult Dashboard()
        {
            var ninguemLogdado = string.IsNullOrEmpty(ObterUsuarioTipoSession());
            
            if (!ninguemLogdado || (uint) TiposUsuario.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession()))
            {

            var pedidos = pedidoRepository.ObterTodos();
            DashboardViewModel dashbordViewModel = new DashboardViewModel();

            foreach ( var pedido in pedidos)
            {
                switch(pedido.Status)
                {
                    case (uint) StatusPedido.APROVADO:
                        dashbordViewModel.PedidosAprovados++;
                    break;
                    case (uint) StatusPedido.REPROVADO:
                        dashbordViewModel.PedidosReprovados++;
                    break;
                    default:
                        dashbordViewModel.PedidosPendentes++;
                        dashbordViewModel.Pedidos.Add(pedido);
                        //deixar na lista de pedido pendente
                    break;
                }
            }
            dashbordViewModel.NomeView = "Dashboard";
            dashbordViewModel.UsuarioEmail = ObterUsuarioSession();
            return View(dashbordViewModel);
            }
            else
            {
                return View ("Erro", new RespostaViewModel(){
                NomeView = "Dashboard",
                Mensagem = "Você não tem permissão para acessar o Dashboard"

                });
            }
        }
    }
}
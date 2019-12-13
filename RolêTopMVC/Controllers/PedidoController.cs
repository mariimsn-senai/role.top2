using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Enums;
using RolêTopMVC.Models;
using RolêTopMVC.Repositorio;
using RolêTopMVC.ViewModels;
using static RolêTopMVC.ViewModels.PedidoViewModel;

namespace RolêTopMVC.Controllers
{

    public class PedidoController : AbstractController
    {
        ProdutoRepository produtoRepository = new ProdutoRepository();
        ClienteRepository clienteRepository = new ClienteRepository();
    
        public IActionResult Registrar(int id)
        {
            AgendamentoViewModel avm= new AgendamentoViewModel();

            // switch (id)
            // {
            //     case (int) ValorPacotes.PacoteSimples:
            //         avm.NomeView = "Simples";
            //         PacoteSimples ps = new PacoteSimples();
            //         avm.PacoteSimples = ps;
            //         break;
            //     case (int) ValorPacotes.PacotePadrao:
            //         avm.NomeView = "Padrao";
            //         PacotePadrao pp = new PacotePadrao();
            //         avm.PacotePadrao = pp;
            //         break;
            //     case (int )ValorPacotes.PacotePremium:
            //         avm.NomeView = "Premium";
            //         PacotePremium prep = new PacotePremium();
            //         avm.PacotePremium = prep;
            //         break;
            // }

            avm.CodigoPacote = id;

            System.Console.WriteLine("====================================================");
            System.Console.WriteLine("Valor do Código do pacote em AgendamentoViewModel (Registrar): ");
            System.Console.WriteLine(avm.CodigoPacote);
            System.Console.WriteLine("====================================================");
            return RedirectToAction("Index","Agendamento", avm);
        }

        public IActionResult Transferir ()
        {
            return RedirectToAction("Index","Login");
        }


        public IActionResult Index()
        {
            
            PedidoViewModel pvm = new PedidoViewModel();
            
            var usuarioLogado = ObterUsuarioSession();
            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            if(!string.IsNullOrEmpty(nomeUsuarioLogado))
            {
                pvm.NomeCliente = nomeUsuarioLogado;
            }
            var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
            if(clienteLogado != null)
            {
                pvm.Cliente = clienteLogado;
            }
            pvm.NomeView = "ADM";
            pvm.UsuarioEmail = usuarioLogado;
            pvm.UsuarioNome = nomeUsuarioLogado;
            
            return View(pvm);
        }

    }
}

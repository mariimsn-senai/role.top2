using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Enums;
using RolêTopMVC.Models;
using RolêTopMVC.Repositorio;
using RolêTopMVC.ViewModels;

namespace RolêTopMVC.Controllers
{
    public class ProdutoController : AbstractController
    {
        ProdutoRepository produtoRepository = new ProdutoRepository();

        ClienteRepository clienteRepository = new ClienteRepository();
    
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
            pvm.NomeView = "Pedido";
            pvm.UsuarioEmail = usuarioLogado;
            pvm.UsuarioNome = nomeUsuarioLogado;
            
            return View(pvm);
        }


        public IActionResult Registrar(IFormCollection form)
        {
            ViewData["Action"] = "Pedido";
            Produto produto = new Produto(){
                data = form["data"],
                horario = form["horario"]
            };
                

            // Cliente cliente = new Cliente(){
            //     Nome = form["nome"],
            //     Email = form["email"]
            
            // };

            var cliente = clienteRepository.ObterPor(ObterUsuarioSession());

            produto.Cliente = cliente;
            
            
            
            if(produtoRepository.Inserir(produto))
            {
            return View("Sucesso", new RespostasViewModel(){
                NomeView = "Pedido",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
                
            }else{
                return View("Erro", new RespostasViewModel(){
                NomeView = "Pedido",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
            
            
        }
    }

        public IActionResult Aprovar (ulong id)
        {
            var produto = produtoRepository.ObterPor(id);
            produto.Status = (uint) StatusPedido.APROVAR;

            if(produtoRepository.Atualizar(produto))
            {
                return RedirectToAction("Index", "Adm");
            }
            else
            {
                return View("Erro", new RespostasViewModel("Não foi possível aprovar este pedido")
                {
                    NomeView = "ADM",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }

        public IActionResult Reprovar (ulong id)
        {
            var produto = produtoRepository.ObterPor(id);
                produto.Status = (uint) StatusPedido.RECUSAR;

            if(produtoRepository.Atualizar(produto))
            {
                return RedirectToAction("Index", "Adm");
            }
            else
            {
                return View("Erro", new RespostasViewModel("Não foi possível reprovar este pedido")
                {
                    NomeView = "ADM",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }
        public IActionResult Readimitir (ulong id)
        {
            var produto = produtoRepository.ObterPor(id);
            produto.Status = (uint) StatusPedido.PENDENTE;

            if(produtoRepository.Atualizar(produto))
            {
                return RedirectToAction("Index", "Adm");
            }
            else
            {
                return View("Erro", new RespostasViewModel("Não foi possível reprovar este pedido")
                {
                    NomeView = "ADM",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }
    }
}
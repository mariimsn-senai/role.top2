using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Enums;
using RolêTopMVC.Models;
using RolêTopMVC.Repositorio;
using RolêTopMVC.ViewModels;

namespace RolêTopMVC.Controllers
{
 public class ClienteController : AbstractController
    {

        private ClienteRepository clienteRepository = new ClienteRepository();
        ProdutoRepository produtoRepository = new ProdutoRepository();
        

        [HttpGet]
        public IActionResult Login()
        {
            return View(new BaseViewModel()
            {
            NomeView = "Login",
            UsuarioEmail = ObterUsuarioSession(),
            UsuarioNome = ObterUsuarioNomeSession()

            });
        }
        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            ViewData["Action"] = "Login";
            try
            {
                System.Console.WriteLine("====================================");
                System.Console.WriteLine(form["email"]);
                System.Console.WriteLine(form["senha"]);
                System.Console.WriteLine("====================================");

                var usuario = form["email"];
                var senha = form["senha"];

                var c = clienteRepository.ObterPor(usuario); 
                //verificação de senha
                if(c != null)
                {
                    if(c.Senha.Equals(senha))
                    {
                        switch(c.TiposUsuario){
                            case (uint) TiposUsuario.CLIENTE:
                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, c.Nome);
                                HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, c.TiposUsuario.ToString());
                                return RedirectToAction("Historico", "Clientee2");        
                            
                            default:
                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, c.Nome);
                                HttpContext.Session.SetString(SESSION_CLIENTE_TIPO, c.TiposUsuario.ToString());
                                return RedirectToAction("Index", "Adm");
                        }


                    }
                    else
                    {
                        return View("Erro" , new RespostasViewModel(){
                            Mensagem = "erro na senha",
                            NomeView = "Login",
                            UsuarioEmail= ObterUsuarioSession(),
                            UsuarioNome= ObterUsuarioNomeSession()
                        });
                    }

                }
                else
                {
                    return View("Erro", new RespostasViewModel($"Usuário {usuario} não encontrado."));
                }

            }
            catch (Exception e)
            {
                //stacktrace mostra para o usuario onde está o erro
                System.Console.WriteLine(e.StackTrace);
                return View("Erro", new RespostasViewModel("deu ruim"));
            }

        }

        public IActionResult Historico ()
        {
            var emailCliente = ObterUsuarioSession();
            var pedidosCliente = produtoRepository.ObterTodosPorCliente(emailCliente);

            return View(new HistoricoViewModel()
            {
                Produto = pedidosCliente,
                NomeView = "Histórico",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

                public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Enums;
using RolêTopMVC.Models;
using RolêTopMVC.Repositorio;
using RolêTopMVC.ViewModels;

namespace RolêTopMVC.Controllers
{
    public class CadastroController : AbstractController
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Index()
        {    
                return View(new BaseViewModel(){
                NomeView = "Cadastro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession() 
            });
        }

        public IActionResult CadastroCliente(IFormCollection form)
        {
            ViewData["Action"] = "Cadastro";
            try
            {
                Cliente cliente = new Cliente(
                    form["nome"],
                    form["idade"],
                    form["email"],
                    form["telefone"],
                    form["endereco"],
                    form["CPF"],
                    form["senha"]
                    );
                    
                    cliente.TiposUsuario = (uint) TiposUsuario.CLIENTE;

                    clienteRepository.Inserir(cliente);
                    return View("Sucesso", new RespostasViewModel()
                    {
                        NomeView = "Cadastro",
                        UsuarioEmail = ObterUsuarioSession(),
                        UsuarioNome = ObterUsuarioNomeSession()

                    });

                

            }catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro" , new BaseViewModel()
                {
                    
                        NomeView = "Cadastro",
                        UsuarioEmail = ObterUsuarioSession(),
                        UsuarioNome = ObterUsuarioNomeSession()
                }
                    );

            }

        }
    }
}
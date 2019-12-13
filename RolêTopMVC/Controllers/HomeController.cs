using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;
using RolêTopMVC.Repositorio;
using RolêTopMVC.ViewModels;

namespace RolêTopMVC.Controllers
{
public class HomeController : AbstractController
    {
        ProdutoRepository ProdutoRepository = new ProdutoRepository();
        public IActionResult Index()
        {
            DashboardViewModel dashbordViewModel = new DashboardViewModel();

            var produtos = ProdutoRepository.ObterTodos();
            dashbordViewModel.NomeView = "Home";
            dashbordViewModel.UsuarioEmail = ObterUsuarioSession();
            dashbordViewModel.Produto = produtos;
            return View(dashbordViewModel);
            }
        }

        
    }
using System.Collections.Generic;
using RolêTopMVC.Models;

namespace RolêTopMVC.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public List<Produto> Produto {get;set;}
        public uint Aceitar {get;set;}
        public uint Recusar {get;set;}
        public uint Pendente {get;set;}


        public DashboardViewModel()
        {
            this.Produto = new List<Produto>();
        }
    }
}
using RolêTopMVC.Controllers;
using RolêTopMVC.ViewModels;

namespace RolêTopMVC.Models
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public string data {get;set;}
        
        public string horario {get;set;}
        public int CodigoPacote {get;set;}
        // public PacoteSimples PacoteSimples {get;set;}
        // public  PacotePadrao PacotePadrao {get;set;}
        // public PacotePremium PacotePremium {get;set;}
        
        public AgendamentoViewModel (){
            // this.PacoteSimples = new PacoteSimples();
            // this.PacotePadrao = new PacotePadrao();
            // this.PacotePremium = new PacotePremium();
        }
        
    }
}
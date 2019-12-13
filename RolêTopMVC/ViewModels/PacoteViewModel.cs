using RolêTopMVC.Enums;
using RolêTopMVC.Models;

namespace RolêTopMVC.ViewModels
{
    public class PacoteViewModel : AgendamentoViewModel
    {
        public int CodigoPacoteSimples {get;set;}
        
        public int CodigoPacotePadrao {get;set;}
        public int CodigoPacotePremium {get;set;}

        public PacoteViewModel()
        {
            this.CodigoPacotePadrao = (int) ValorPacotes.PacotePadrao;
            this.CodigoPacoteSimples = (int) ValorPacotes.PacoteSimples;
            this.CodigoPacotePremium = (int) ValorPacotes.PacotePremium;
        }

    }
}
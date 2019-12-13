using System;

namespace RolêTopMVC.Models
{
    public class PacotePremium : Produto
    {
        public PacotePremium()
        {
            this.Nome = "Pacote Premium";
            this.Valor = 10000;
            this.luz = "SIM";
            this.som = "NÃO";
            this.data = DateTime.Now.ToString();
            this.Id = 2;
        }
    }
}
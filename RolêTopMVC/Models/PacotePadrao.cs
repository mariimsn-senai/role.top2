using System;

namespace RolêTopMVC.Models
{
    public class PacotePadrao : Produto
    {
        public PacotePadrao()
        {
            this.Nome = "Pacote Simples";
            this.Valor = 10000;
            this.luz = luz;
            this.som = som;
            this.data = DateTime.Now.ToString();
            this.Id = 3;
        }
    }
}
using System;

namespace RolêTopMVC.Models
{
    public class PacoteSimples : Produto
    {
        public PacoteSimples()
        {
            this.Nome = "Pacote Simples";
            this.Valor = 10000;
            this.luz = "NÃO";
            this.som = "NÃO";
            this.data = DateTime.Now.ToString();
            this.Id = 1;
        }
    }
}
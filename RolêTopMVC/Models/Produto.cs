using System;
using System.Collections.Generic;

namespace RolêTopMVC.Models
{
    public class Produto
    {
        public ulong Id {get;set;}

        public Cliente Cliente {get;set;}
        public PacoteSimples pacotesimples {get;set;}
        public string Nome {get;set;}
        public double Valor {get;set;}
        public string luz {get;set;}
        public string som {get;set;}

        public string data {get;set;}
        
        public string horario {get;set;}

        public string parcelas {get;set;}

        public uint Status {get;set;}

        public Produto()
        {
            this.Cliente = new Cliente();
        }
    }
}
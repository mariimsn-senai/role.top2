using System;

namespace RolêTopMVC.Models
{
    public class Cliente
    {
        public string Nome {get;set;}
        public string Idade {get;set;}
        public string Email {get;set;}
        public string Telefone {get;set;}
        public string Endereco {get;set;}
        public string CPF {get;set;}
        public string Senha {get;set;}

        public uint TiposUsuario {get;set;}
        

        public Cliente()
        {

        }
        
        public Cliente(string nome, string idade, string email, string telefone, string endereco, string CPF, string senha)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Email = email;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.CPF = CPF;
            this.Senha = senha;
            

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using RolêTopMVC.Models;

namespace RolêTopMVC.Repositorio
{
            public class ClienteRepository : RepositoryBaase
    {
        private const string PATH = "DataBase/Cliente.csv";

        public ClienteRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Cliente cliente)
        {
            var linha = new string[] { PrepararRegistroCSV(cliente) };
            File.AppendAllLines(PATH, linha);

            return true;
        }

        public Cliente ObterPor(string email)
        {
            var linhas = File.ReadLines(PATH);
            foreach (var item in linhas)
            {
                if(ExtrairValorDoCampo("email", item).Equals(email))
                {
                    Cliente c = new Cliente();
                    c.Nome = ExtrairValorDoCampo("nome", item);
                    c.Idade = ExtrairValorDoCampo("idade", item);
                    c.Email = ExtrairValorDoCampo("email", item);
                    c.Telefone = ExtrairValorDoCampo("telefone", item);
                    c.Endereco = ExtrairValorDoCampo("endereco", item);
                    c.CPF= ExtrairValorDoCampo("CPF", item);
                    c.Senha = ExtrairValorDoCampo("senha", item);
                    c.TiposUsuario = uint.Parse(ExtrairValorDoCampo("tipo_usuario", item));
                    return c;
                }                
            }
            return null;

        }

        private string PrepararRegistroCSV(Cliente cliente)
        {
            return $"tipo_usuario={cliente.TiposUsuario};nome={cliente.Nome};idade={cliente.Idade};email={cliente.Email};telefone={cliente.Telefone};endereco={cliente.Endereco};CPF={cliente.CPF};senha={cliente.Senha};";
        }
    }
}
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using RolêTopMVC.Models;

namespace RolêTopMVC.Repositorio
{
    public class ProdutoRepository : RepositoryBaase
    {
        private const string PATH = "DataBase/Pedidos.csv";

        public ProdutoRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir(Produto Produto)
        {
            try{
            var quantidadeEvento = File.ReadAllLines(PATH).Length;
            Produto.Id = (ulong) ++ quantidadeEvento;

            var linha = new string[]{PrepararEventoCSV(Produto)};
            File.AppendAllLines(PATH, linha);

            return true;
            }catch(IOException e){
                System.Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public List<Produto> ObterTodosPorCliente(string emailCliente)
        {

            var produtos = ObterTodos();
            List<Produto> pedidosCliente = new List<Produto>();

            foreach (var produto in produtos)
            {
                if(produto.Cliente.Email.Equals(emailCliente))
                {
                    pedidosCliente.Add(produto);
                }
            }
            return pedidosCliente;
        }

        public List<Produto> ObterTodos()
        {
            var linhas = File.ReadAllLines(PATH);
            List<Produto> produtos = new List<Produto>();

            foreach (var item in linhas)
            {
                Produto produto = new Produto();


                    produto.Id = ulong.Parse(ExtrairValorDoCampo("Id", item));
                    produto.Cliente.Email = ExtrairValorDoCampo("cliente_email", item);
                    produto.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", item);
                    produto.Status = uint.Parse(ExtrairValorDoCampo("status_pedido", item));
                    produto.Nome = ExtrairValorDoCampo("Nome", item);
                    produto.data= ExtrairValorDoCampo("data", item);
                    produto.horario = ExtrairValorDoCampo("horario", item);
                    

                produtos.Add(produto);
            }
            return produtos;
        }

        private string PrepararEventoCSV(Produto produto)
        {
            return $"Id={produto.Id};cliente_email={produto.Cliente.Email};cliente_nome={produto.Cliente.Nome};status_pedido={produto.Status};Nome={produto.Nome};data={produto.data};horario={produto.horario}";
        }

        public bool Atualizar(Produto pedido)
        {
            var pedidosTotais = File.ReadAllLines(PATH);
            var pedidoCSV = PrepararEventoCSV(pedido);
            var linhaPedido = -1;
            var resultado = false;

            for (int i = 0; i < pedidosTotais.Length; i++)
            {
                var idConvertido = ulong.Parse(ExtrairValorDoCampo("Id" , pedidosTotais[i]));
                if(pedido.Id.Equals(idConvertido))
                {
                    linhaPedido = i;
                    resultado = true;
                    break;
                }
            }
            
            if(resultado)
            {
                pedidosTotais[linhaPedido] = pedidoCSV;
                File.WriteAllLines(PATH, pedidosTotais);
            }

            return resultado;
        }

        public Produto ObterPor(ulong id)
        {
            var pedidoTotais = ObterTodos();
            foreach (var produto in pedidoTotais)
            {
                if(id.Equals(produto.Id))
                {
                    return produto;
                }
            }
            return null;
        }
        
    }
}
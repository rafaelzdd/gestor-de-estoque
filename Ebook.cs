using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace gestor_de_estoque
{
    [System.Serializable]
    internal class Ebook : Produto, IEstoque
    {
        public string autor;
        private int qtdVendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar venda no Ebook {nome}\n===================================\n");
            Console.WriteLine("Digite a qtd de vendas que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            qtdVendas += entrada;
            Console.WriteLine("Venda registrada.");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            throw new NotImplementedException();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vendas: {qtdVendas}");
            Console.WriteLine("==============================");
        }
    }
}

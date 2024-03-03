using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestor_de_estoque
{
    [System.Serializable]
    internal class Curso : Produto, IEstoque
    {
        public string autor;
        private int qtdVagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no curso {nome}\n===================================\n");
            Console.WriteLine("Digite a qtd de vagas que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            qtdVagas += entrada;
            Console.WriteLine("Entrada registrada.");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Ocupar vagas no curso {nome}\n===================================\n");
            Console.WriteLine("Digite a qtd de vagas que você quer ocupar: ");
            int entrada = int.Parse(Console.ReadLine());
            qtdVagas -= entrada;
            Console.WriteLine("Evento registrado.");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas preenchidas: {qtdVagas}");
            Console.WriteLine("==============================");
            
        }
    }
}

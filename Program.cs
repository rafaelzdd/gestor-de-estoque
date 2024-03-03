using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace gestor_de_estoque
{
    internal class Program
    {
        static List <IEstoque> produtos = new List<IEstoque>();
        enum Menu
        {
            Listar = 1, Adicionar, Remover, Entrada, Saida, Sair
        }
        static void Main(string[] args)
        {
            Carregar();

            bool escolheuSair = false;

            while (escolheuSair == false)
            {
                Console.WriteLine("SISTEMA DE ESTOQUE\n====================\n");
                Console.WriteLine("1- Listar\n2- Adicionar produto\n3- Remover produto\n" +
                "4- Registrar entrada de produto\n5- Registrar saída de produto\n6- Sair");
                int opcao = int.Parse(Console.ReadLine());
                Menu escolha = (Menu)opcao;

                if(opcao > 0 && opcao < 7)
                {
                switch(escolha)
                {
                    case Menu.Listar:
                        Listar();
                    break;

                    case Menu.Adicionar:
                        Cadastrar();
                    break;

                    case Menu.Remover:
                        Remover();
                    break;

                    case Menu.Entrada:
                        Entrada();
                    break;

                    case Menu.Saida:
                        Saida();    
                    break;

                    case Menu.Sair:
                        escolheuSair = true;
                    break;
                }
                } 
                
                Console.Clear();
            }

        }

        static void Cadastrar()
        {
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine("1- Produto Fisico\n2- Ebook\n3- Curso");
            string opcao = Console.ReadLine();
            int opcaoInt = int.Parse(opcao);
            switch (opcaoInt)
            {
                case 1:
                    CadastrarPFisico();
                break;
                case 2:
                    CadastrarEbook();
                break;
                case 3:
                    CadastrarCurso();
                break;
                case 4:
                    break;
            }
        }

        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastrando produto fisico\n====================== ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando ebook\n====================== ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            Ebook ebook = new Ebook(nome, preco, autor);
            produtos.Add(ebook);
            Salvar();
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando curso\n====================== ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            Curso curso = new Curso(nome, preco, autor);
            produtos.Add(curso);
            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            } 
            catch (Exception ex)
            {
                produtos = new List<IEstoque>();
            }

            stream.Close();
        }

        static void Listar()
        {
            Console.WriteLine("Lista de produtos:\n==============================");
            int i = 0;

            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

        static void Remover()
        {
            Listar();
            Console.WriteLine("Digite o ID do elemento que você quer remover: ");
            int id = int.Parse(Console.ReadLine());

            if(id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
            
        }

        static void Entrada()
        {
            Listar();
            Console.WriteLine("Digite o ID do elemento que você quer dar entrada: ");
            int id = int.Parse(Console.ReadLine());

            if(id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }

        static void Saida()
        {
            Listar();
            Console.WriteLine("Digite o ID do elemento que você quer dar saída: ");
            int id = int.Parse(Console.ReadLine());

            if(id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }
    }
}

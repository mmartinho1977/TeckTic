using System;
using System.Collections.Generic;
using Pantry.entities;
using Pantry.dataaccess;

namespace Pantry.ui
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            int opcao;

            do
            {
                Console.Clear();
                opcao = MenuGeral();

                switch (opcao)
                {
                    case 1:
                        OpcaoProduto();
                        break;
                    case 2:
                        //OpcaoCategoria();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Até breve!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 0);
        }


        static int MenuGeral()
        {
            int opcao;

            Console.WriteLine("=========================================================================================");
            Console.WriteLine("|                                          MENU                                         |");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                       |");
            Console.WriteLine("|    1 ...................................Menu Produtos.................................|");
            Console.WriteLine("|    2 ...................................Menu Categorias...............................|");
            Console.WriteLine("|    0 ...................................Sair..........................................|");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Insira uma opcao: ");
            opcao = int.Parse(Console.ReadLine());

            return opcao;
        }


        static int MenuProduto()
        {
            int opcao;

            Console.WriteLine("=========================================================================================");
            Console.WriteLine("|                                      PRODUTOS                                         |");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                       |");
            Console.WriteLine("|    1 ................................Novo Produto.....................................|");
            Console.WriteLine("|    2 ................................Ficha de Produto.................................|");
            Console.WriteLine("|    3 ................................Editar Produto...................................|");
            Console.WriteLine("|    4 ................................Eliminar Produto.................................|");
            Console.WriteLine("|    5 ................................Listar Produtos..................................|");
            Console.WriteLine("|    0 ................................Sair.............................................|");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Insira uma opcao: ");
            opcao = int.Parse(Console.ReadLine());

            return opcao;
        }


        static int MenuCategoria()
        {
            int opcao;

            Console.WriteLine("=========================================================================================");
            Console.WriteLine("|                                      CATEGORIAS                                       |");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                       |");
            Console.WriteLine("|    1 ................................Nova Categoria...................................|");
            Console.WriteLine("|    2 ................................Ficha de Categoria...............................|");
            Console.WriteLine("|    3 ................................Editar Categoria.................................|");
            Console.WriteLine("|    4 ................................Eliminar Categoria...............................|");
            Console.WriteLine("|    5 ................................Listar Categorias................................|");
            Console.WriteLine("|    0 ................................Sair.............................................|");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Insira uma opcao: ");
            opcao = int.Parse(Console.ReadLine());

            return opcao;
        }

        static void OpcaoProduto()
        {
            int opcao, res;
            Produto p1;
            List<Produto> produtos = new List<Produto>();

            do
            {
                Console.Clear();
                opcao = MenuProduto();
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        p1 = CriarProduto();
                        produtos.Add(p1);
                        res = Produtos.InsertProtuto(p1);
                        if (res == 1)
                        {
                            Console.WriteLine("Inserido com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Ocorreu um erro!");
                        }
                        break;
                    case 2:

                        
                        break;
                    case 3:
                        

                        break;
                    case 4:
                       

                        break;
                    case 5:
                        produtos = Produtos.SelectAllProdutos();
                        ListarProdutos(produtos);


                        break;
                    case 6:

                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.ReadKey();
            } while (opcao != 0);


        }

        static void OpcaoCategoria()
        {

        }

        static Produto CriarProduto()
        {
            Produto p1;

            p1 = new Produto();

            Console.Write("DESCRICAO: ");
            p1.Descricao = Console.ReadLine();

            Console.Write("PRECO: ");
            p1.Preco = decimal.Parse(Console.ReadLine().Replace('.',','));

            Console.Write("QUANTIDADE ATUAL: ");
            p1.QuantidadeAtual = int.Parse(Console.ReadLine());

            Console.Write("QUANTIDADE MAXIMA: ");
            p1.QuantidadeMaxima = int.Parse(Console.ReadLine());

            Console.Write("QUANTIDADE MINIMA: ");
            p1.QuantidadeMinima = int.Parse(Console.ReadLine());

            Console.Write("CATEGORIA: ");
            p1.Categoria = new Categoria();
            p1.Categoria.Id = int.Parse(Console.ReadLine());


            return p1;
        }

        static void ListarProdutos(List<Produto> produtos)
        {
            foreach (Produto p in produtos)
            {
                Console.WriteLine($"{p.Codigo} - {p.Descricao}");
            }
        }
    }
}

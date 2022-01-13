using BeHealthy.dataaccess;
using BeHealthy.entities;
using System;
using System.Collections.Generic;

namespace BeHealthy.tests
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static Alimento CriarAlimento()
        {
            Alimento a1;
            a1 = new Alimento();

            Console.WriteLine("Nome");
            a1.Nome = Console.ReadLine();

            Console.WriteLine("Descrição");
            a1.Descricao = Console.ReadLine();

            Console.WriteLine("Valor Energético");
            a1.ValorEnergetico = int.Parse(Console.ReadLine());

            Console.WriteLine("Lipidos");
            a1.Lipidos = float.Parse(Console.ReadLine());

            Console.WriteLine("Hidratos");
            a1.Hidratos = float.Parse(Console.ReadLine());

            Console.WriteLine("Sal");
            a1.Sal = float.Parse(Console.ReadLine());

            Console.WriteLine("Fibra");
            a1.Fibra = float.Parse(Console.ReadLine());

            Console.WriteLine("Proteina");
            a1.Proteina = float.Parse(Console.ReadLine());

            Console.WriteLine("Ferro");
            a1.Ferro = float.Parse(Console.ReadLine());

            Console.WriteLine("Imagem");
            a1.Imagem = Console.ReadLine();

            Console.WriteLine("IDUtilizador");
            a1.IDUtilizador = int.Parse(Console.ReadLine());

            Console.WriteLine("IDTipoAlimentos");
            a1.IDTipoAlimentos = int.Parse(Console.ReadLine());

            return a1;

        }

        static TipoAlimento CriarTipoAlimento()
        {
            TipoAlimento ta1;
            ta1 = new TipoAlimento();

            Console.WriteLine("Descricao");
            ta1.Descricao = Console.ReadLine();
            return ta1;

        }

        static Alimento EditarAlimento(Alimento a1)
        {
            //a1 = new Alimento();

            Console.WriteLine("Nome");
            a1.Nome = Console.ReadLine();

            Console.WriteLine("Descrição");
            a1.Descricao = Console.ReadLine();

            Console.WriteLine("Valor Energético");
            a1.ValorEnergetico = int.Parse(Console.ReadLine());

            Console.WriteLine("Lipidos");
            a1.Lipidos = float.Parse(Console.ReadLine());

            Console.WriteLine("Hidratos");
            a1.Hidratos = float.Parse(Console.ReadLine());

            Console.WriteLine("Sal");
            a1.Sal = float.Parse(Console.ReadLine());

            Console.WriteLine("Fibra");
            a1.Fibra = float.Parse(Console.ReadLine());

            Console.WriteLine("Proteina");
            a1.Proteina = float.Parse(Console.ReadLine());

            Console.WriteLine("Ferro");
            a1.Ferro = float.Parse(Console.ReadLine());

            Console.WriteLine("Imagem");
            a1.Imagem = Console.ReadLine();

            return a1;

        }

        static TipoAlimento EditarTipoAlimentos(TipoAlimento ta1)
        {
            //a1 = new Alimento();

            Console.WriteLine("Descricao:");
            ta1.Descricao = Console.ReadLine();

            return ta1;

        }





        static int MenuGeral()
        {
            int opcao;
            Console.WriteLine("============================================");
            Console.WriteLine("|                  MENU                    |");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("|                                          |");
            Console.WriteLine("|    1...........Menu Utilizadores.........|");
            Console.WriteLine("|    2...........Menu Alimentos............|");
            Console.WriteLine("|    3...........Menu Tipo Alimento........|");
            Console.WriteLine("|    0...........Sair......................|");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Insira uma opção:");
            opcao = int.Parse(Console.ReadLine());

            return opcao;

        }

        static int MenuAlimento()
        {
            int produto;
            Console.WriteLine("============================================================");
            Console.WriteLine("|                           Alimentos                       |");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("|    1-----------Novo Alimento------------------------------|");
            Console.WriteLine("|    2-----------Ficha de Alimento--------------------------|");
            Console.WriteLine("|    3-----------Editar Alimento----------------------------|");
            Console.WriteLine("|    4-------Eliminar Alimento------------------------------|");
            Console.WriteLine("|    5------------Listar Alimentos---------------------------|");
            Console.WriteLine("|    0-------------Sair------------------------------------|");
            Console.WriteLine("Produto");
            produto = int.Parse(Console.ReadLine());

            return produto;

        }
        static int MenuTipoAlimentos()
        {
            int tipoalimento;
            Console.WriteLine("============================================================");
            Console.WriteLine("|                   Tipo de Alimentos                      |");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("|    1-----------Novo Tipo de Alimento---------------------|");
            Console.WriteLine("|    2-----------Ficha de Tipo de Alimentos----------------|");
            Console.WriteLine("|    3-----------Editar Tipo de Alimentos------------------|");
            Console.WriteLine("|    4-----------Eliminar Tipo de Alimentos----------------|");
            Console.WriteLine("|    5-----------Listar Tipo de Alimentos------------------|");
            Console.WriteLine("|    0-----------Sair--------------------------------------|");
            Console.WriteLine("Tipo de Alimentos");
            tipoalimento = int.Parse(Console.ReadLine());

            return tipoalimento;



        }

        static void OpcaoAlimento()
        {
            int opcao, res;
            Alimento a1;
            int idAlimento;
            List<Alimento> alimentos = new List<Alimento>();
            alimentos = Alimentos.SelectAllAlimentos();

            do
            {
                Console.Clear();
                opcao = MenuAlimento();
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        a1 = CriarAlimento();
                        alimentos.Add(a1);
                        res = Alimentos.InserirAlimento(a1);
                        if (res == 1)
                        {
                            Console.WriteLine("Inserido com Sucesso");

                        }
                        else
                        {
                            Console.WriteLine("Ocorreu um Erro");
                        }
                        break;


                    case 2:
                        ListarAlimentos(alimentos);

                        Console.WriteLine("Escolha um alimento");
                        idAlimento = int.Parse(Console.ReadLine());

                        a1 = new Alimento();


                        a1 = Alimentos.SelectAlimentoById(idAlimento);





                        break;

                    case 3:

                        ListarAlimentos(alimentos);

                        Console.WriteLine("Escolha um alimento");
                        idAlimento = int.Parse(Console.ReadLine());

                        a1 = new Alimento();
                        foreach (Alimento a in alimentos)
                        {
                            if (a.Id == idAlimento)
                            {
                                a1 = a;
                                break;
                            }
                        }

                        a1 = EditarAlimento(a1);

                        res = Alimentos.UpdateAlimentos(a1);

                        if (res >= 1)
                        {
                            Console.WriteLine("Editado com Sucesso");
                        }
                        else
                        {
                            Console.WriteLine("Erro");
                        }



                        break;

                    case 4:
                        ListarAlimentos(alimentos);


                        Console.WriteLine("ID:");
                        idAlimento = int.Parse(Console.ReadLine());

                        res = Alimentos.DelectAlimentos(idAlimento);
                        if (res >= 1)
                        {
                            Console.WriteLine("Eliminado com Sucesso");
                        }
                        else
                        {
                            Console.WriteLine("Erro");
                        }



                        break;

                    case 5:
                        alimentos = Alimentos.SelectAllAlimentos();
                        ListarAlimentos(alimentos);




                        break;


                    case 0:
                        Console.Clear();
                        Console.WriteLine("Até Breve!");

                        break;

                    default:
                        Console.WriteLine("Opçao Inválida!");
                        break;


                }

            } while (opcao != 0);
        }

        static void OpcaoTipoAlimentos()
        {
            {
                int opcao, res;
                int IDTipoAlimento;
                TipoAlimento ta1;
                List<TipoAlimento> tipoAlimentos = new List<TipoAlimento>();
                tipoAlimentos = TipoAlimentos.SelectAllTipoAlimentos();

                do
                {
                    Console.Clear();
                    opcao = MenuTipoAlimentos();
                    Console.Clear();

                    switch (opcao)
                    {
                        case 1:
                            ta1 = CriarTipoAlimento();
                            tipoAlimentos.Add(ta1);
                            res = TipoAlimentos.InsertTipoAlimento(ta1);

                            if (res == 1)
                            {
                                Console.WriteLine("Inserido com Sucesso");

                            }
                            else
                            {
                                Console.WriteLine("Ocorreu um Erro");
                            }
                            break;


                        case 2:
                            ListarTipoAlimentos(tipoAlimentos);

                            Console.WriteLine("Escolha um alimento");
                            IDTipoAlimento = int.Parse(Console.ReadLine());

                            ta1 = new TipoAlimento();


                            ta1 = TipoAlimentos.SelectTipoAlimentosById(IDTipoAlimento);



                            break;

                        case 3:

                            ListarTipoAlimentos(tipoAlimentos);


                            Console.WriteLine("Escolha um TipoAlimento");
                            IDTipoAlimento = int.Parse(Console.ReadLine());

                            ta1 = new TipoAlimento();
                            foreach (TipoAlimento a in tipoAlimentos)
                            {
                                if (a.IDTipoAlimentos == IDTipoAlimento)
                                {
                                    ta1 = a;
                                    break;
                                }
                            }

                            ta1 = EditarTipoAlimentos(ta1);

                            res = TipoAlimentos.UpdateTipoAlimentos(ta1);

                            if (res >= 1)
                            {
                                Console.WriteLine("Editado com Sucesso");
                            }
                            else
                            {
                                Console.WriteLine("Erro");
                            }



                            break;


                        case 4:

                            ListarTipoAlimentos(tipoAlimentos);


                            Console.WriteLine("ID:");
                            IDTipoAlimento = int.Parse(Console.ReadLine());

                            res = TipoAlimentos.DelectTipoAlimentos(IDTipoAlimento);
                            if (res >= 1)
                            {
                                Console.WriteLine("Eliminado com Sucesso");
                            }
                            else
                            {
                                Console.WriteLine("Erro");
                            }


                            break;


                        case 5:
                            tipoAlimentos = TipoAlimentos.SelectAllTipoAlimentos();
                            ListarTipoAlimentos(tipoAlimentos);


                            break;



                        case 0:

                            Console.Clear();
                            Console.WriteLine("Até Breve!");

                            break;

                        default:
                            Console.WriteLine("Opçao Inválida!");
                            break;



                    }

                } while (opcao != 0);

                Console.ReadKey();
            }
        }

        static void ListarAlimentos(List<Alimento> alimentos)
        {
            foreach (Alimento a in alimentos)
            {
                Console.WriteLine($"{a.Id},{a.Descricao}");
            }

            Console.ReadKey();
        }

        static void ListarTipoAlimentos(List<TipoAlimento> tipoAlimentos)
        {
            foreach (TipoAlimento a in tipoAlimentos)
            {
                Console.WriteLine($"{a.IDTipoAlimentos}, {a.Descricao}");
            }

            Console.ReadKey();
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


                        break;
                    case 2:
                        OpcaoAlimento();

                        break;
                    case 3:
                        OpcaoTipoAlimentos();

                        break;

                    case 0:
                        Console.Clear();
                        Console.WriteLine("Até Breve!");

                        break;

                    default:
                        Console.WriteLine("Opçao Inválida!");
                        break;
                }


            } while (opcao != 0);
        }
    }
}

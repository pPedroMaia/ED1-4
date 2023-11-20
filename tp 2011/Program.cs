using System;
using System.Linq;

namespace ProjetoTransporte
{
    class Program
    {

            static Garagens garagens;
            static Veiculos frota;
            static Viagens viagens;
            static int op;

            static void Main(string[] args)
            {
                garagens = new Garagens();
                frota = new Veiculos();
                viagens = new Viagens();

                carregamentoInicial();

                construaOMenu();
            }


            static void carregamentoInicial()
            {
                Garagem congonhas = new Garagem("Congonhas - CGH");
                Garagem guarulhos = new Garagem("Guarulhos - GRU");
                garagens.incluir(congonhas);
                garagens.incluir(guarulhos);
                Veiculo van1 = new Veiculo("CBT-0001", 8);
                Veiculo van2 = new Veiculo("CBT-0002", 8);
                Veiculo van3 = new Veiculo("CBT-0003", 8);
                Veiculo van4 = new Veiculo("CBT-0004", 8);
                Veiculo van5 = new Veiculo("CBT-0005", 8);
                Veiculo van6 = new Veiculo("CBT-0006", 8);
                Veiculo van7 = new Veiculo("CBT-0007", 8);
                Veiculo van8 = new Veiculo("CBT-0008", 8);
                frota.incluir(van1);
                frota.incluir(van2);
                frota.incluir(van3);
                frota.incluir(van4);
                frota.incluir(van5);
                frota.incluir(van6);
                frota.incluir(van7);
                frota.incluir(van8);
            }

            static void construaOMenu()
            {

                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Cadastrar veículo ");
                    Console.WriteLine("2. Cadastrar garagem");
                    Console.WriteLine("3. Iniciar jornada ");
                    Console.WriteLine("4. Encerrar jornada");
                    Console.WriteLine("5. Liberar viagem de uma determinada origem para um determinado destino ");
                    Console.WriteLine("6. Listar veículos em determinada garagem (informando a qtde de veículos e seu potencial de transporte)");
                    Console.WriteLine("7. Informar qtde de viagens efetuadas de uma determinada origem para um determinado destino");
                    Console.WriteLine("8. Listar viagens efetuadas de uma determinada origem para um determinado destino");
                    Console.WriteLine("9. Informar qtde de passageiros transportados de uma determinada origem para um determinado destino");
                    Console.WriteLine("0. Sair");
                    Console.Write("\nDigite a opção desejada: ");

                    try
                    {
                        op = int.Parse(Console.ReadLine());
                        if (op > 9)
                        {
                            Console.Clear();
                            Console.Write("Opção inválida, escolha um número entre 0 e 9");
                            Console.ReadKey();
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        Console.Write("Opção inválida, escolha um número entre 0 e 9");
                        Console.ReadKey();
                        continue;
                    }

                    switch (op)
                    {
                        case 1: cadastraVeiculo(); break;
                        case 2: cadastrarGaragem(); break;
                        case 3: iniciarJornada(); break;
                        case 4: encerrarJornada(); break;
                        case 5: liberarViagem(); break;
                        case 6: listarVeicPorGaragem(); break;
                        case 7: informarQuantViagens(); break;
                        case 8: listarViagens(); break;
                        case 9: informarQuantPassageiros(); break;
                    }
                } while (op != 0);
            }

            static void cadastraVeiculo()
            {
                if (!garagens.JornadaAtiva)
                {
                    string placa;
                    int lotacao;

                    Console.Clear();
                    Console.Write("Digite a placa: ");
                    placa = Console.ReadLine();
                    lotacao = recebeInt("Informe a lotação: ");
                    frota.incluir(new Veiculo(placa, lotacao));
                }
                else
                {
                    Console.Clear();
                    Console.Write("Jornada já foi iniciada");
                }
                Console.ReadKey();
            }

            static void cadastrarGaragem()
            {
                if (!garagens.JornadaAtiva)
                {
                    Console.Clear();
                    Console.Write("Informe o nome da garagem: ");
                    string nomeGaragem = Console.ReadLine();

                    Garagem garagem = new Garagem(nomeGaragem);
                    garagens.incluir(garagem);
                    Console.Clear();
                    Console.Write("Garagem adicionada com sucesso!");
                    Console.ReadKey();
                    construaOMenu();

                }
                else
                {
                    Console.Clear();
                    Console.Write("Jornada já foi iniciada");
                    Console.ReadKey();
                }
                Console.ReadKey();
            }


            static void iniciarJornada()
            {

                if (!garagens.JornadaAtiva)
                {
                    garagens.inciarJornada(frota.veiculos);
                    Console.Clear();
                    Console.Write("Jornada iniciada com sucesso!");
                }
                else
                {
                    Console.Clear();
                    Console.Write("Jornada já foi iniciada");
                }
                Console.ReadKey();
            }
            static void encerrarJornada()
            {

                garagens.encerrarJornada();
                foreach (Veiculo veiculo in frota.veiculos)
                {
                    foreach (Viagem viagem in viagens.viagens)
                    {
                        Console.Clear();
                        Console.WriteLine("Encerramento de Frota\n");
                        if (viagem.Veiculo.Equals(veiculo))
                        {
                            Console.Write("Veiculo: " + veiculo.Id + ". " + " Placa: " + veiculo.Placa + " Transportados: " + veiculo.Lotacao + " Origem: " + viagem.Origem.Local + " Destino " + viagem.Destino.Local);
                        }
                    }
                }
                frota = new Veiculos();

                Console.WriteLine("\nFim da Jornada!");
                Console.ReadKey();

            }


            static void liberarViagem()
            {
                int idOrigem, idDestino;

                Veiculo veiculo;
                Garagem garOrigem = null, garDestino = null;


                if (garagens.JornadaAtiva)
                {
                    Console.Clear();
                    mostreGaragens();

                    Console.Write("Digite o ID origem: ");
                    idOrigem = int.Parse(Console.ReadLine());

                    Console.Write("Digite o ID destino: ");
                    idDestino = int.Parse(Console.ReadLine());

                    foreach (Garagem garagem in garagens.garagens)
                    {
                        if (garagem.Id == idOrigem)
                            garOrigem = garagem;
                        if (garagem.Id == idDestino)
                            garDestino = garagem;
                    }
                    if (garOrigem == null && garDestino == null)
                    {
                        Console.Clear();
                        Console.Write("Origem ou Destino não existem");
                        Console.ReadKey();
                    }
                    else if (garOrigem.Id == garDestino.Id)
                    {
                        Console.Clear();
                        Console.Write("Origem igual destino");
                        Console.ReadKey();
                    }
                    else if (garOrigem.veiculos.Count() != 0)
                    {
                        veiculo = garOrigem.veiculos.Pop();
                        garDestino.veiculos.Push(veiculo);
                        Viagem viagem = new Viagem(veiculo, garOrigem, garDestino);
                        Transporte tranporte = new Transporte(veiculo, veiculo.Lotacao);

                        Console.Clear();
                        Console.Write("Viagem iniciada com sucesso!");
                        Console.ReadKey();

                        viagens.incluir(viagem);
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("Garagem vazia");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.Write("Jornada ainda não foi iniciada");
                    Console.ReadKey();
                }
                Console.ReadKey();
            }


            static void listarVeicPorGaragem()
            {
                int idGaragem;

                if (garagens.JornadaAtiva)
                {
                    mostreGaragens();

                    Console.Clear();
                    Console.Write("Qual o ID da Garagem: ");
                    idGaragem = int.Parse(Console.ReadLine());


                    foreach (Garagem g in garagens.garagens)
                    {
                        if (g.Id == idGaragem)
                        {
                            Console.WriteLine("Garagem: " + g.Local);
                            Console.WriteLine("Potencial de transporte: " + g.potencialDeTransporte());
                            foreach (Veiculo v in g.veiculos)
                            {
                                Console.WriteLine("Veículo id: " + v.Id + " - Lotação: " + v.Lotacao);
                            }
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.Write("Jornada ainda não foi iniciada");
                }
                Console.ReadKey();
            }

            static void informarQuantViagens()
            {
                int idOrigem, idDestino, contViagem = 0;
                if (garagens.JornadaAtiva)
                {
                    mostreGaragens();

                    Console.Clear();

                    Console.Write("Digite o ID origem: ");
                    idOrigem = int.Parse(Console.ReadLine());

                    Console.Write("Digite o ID destino: ");
                    idDestino = int.Parse(Console.ReadLine());

                    if (viagens.viagens.Count != 0)
                    {
                        foreach (Viagem viagem in viagens.viagens)
                        {
                            if (viagem.Origem.Id == idOrigem && viagem.Destino.Id == idDestino)
                                ++contViagem;
                        }
                        Console.Clear();
                        Console.Write("Esse trecho possui " + contViagem + " viagen(s) feita(s)");
                        Console.ReadKey();
                    }
                    if (contViagem == 0)
                    {
                        Console.Clear();
                        Console.Write("Esse trecho ainda não possui viagens feitas");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.Write("Jornada ainda não foi iniciada");
                }
                Console.ReadKey();

            }

            static void listarViagens()
            {
                int idOrigem, idDestino;

                if (garagens.JornadaAtiva)
                {
                    mostreGaragens();

                    Console.Clear();

                    Console.Write("Digite o ID origem: ");
                    idOrigem = int.Parse(Console.ReadLine());

                    Console.Write("Digite o ID destino: ");
                    idDestino = int.Parse(Console.ReadLine());

                    if (viagens.viagens.Count != 0 && idDestino != idOrigem)
                    {
                        foreach (Viagem viagem in viagens.viagens)
                        {
                            if (viagem.Origem.Id == idOrigem && viagem.Destino.Id == idDestino)
                                Console.WriteLine("Lista de viagens:");
                            Console.WriteLine("Viagem nº: " + viagem.Id + ". Origem: " + viagem.Origem.Local + " Destino: " + viagem.Destino.Local);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("Esse trecho ainda não possui viagens feitas");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.Write("Jornada ainda não foi iniciada");
                }
                Console.ReadKey();
            }

            static void informarQuantPassageiros()
            {
                int idOrigem, idDestino, quantidade = 0;

                if (garagens.JornadaAtiva)
                {
                    mostreGaragens();

                    Console.Clear();

                    Console.Write("Digite o ID origem: ");
                    idOrigem = int.Parse(Console.ReadLine());

                    Console.Write("Digite o ID destino: ");
                    idDestino = int.Parse(Console.ReadLine());

                    if (viagens.viagens.Count != 0)
                    {
                        foreach (Viagem viagem in viagens.viagens)
                        {
                            if (viagem.Origem.Id == idOrigem && viagem.Destino.Id == idDestino)
                                quantidade += viagem.Veiculo.Lotacao;
                        }
                        Console.WriteLine("Esse trecho possui " + quantidade + " passageiros transportados");
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("Esse trecho ainda não possui viagens feitas");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.Write("Jornada ainda não foi iniciada");
                }
                Console.ReadKey();
            }

            static public int recebeInt(String str)
            {
                try
                {
                    Console.Write(str);
                    return int.Parse(Console.ReadLine());
                }
                catch
                {

                    Console.Write("\nDigite um número inteiro: ");
                    return recebeInt(str);
                }
            }


            static void mostreGaragens()
            {
                Console.WriteLine("Origens e destinos possíveis: ");
                Console.WriteLine("ID  |  GARAGEM");

                foreach (Garagem g in garagens.garagens)
                {
                    Console.WriteLine(g.Id + ". " + g.Local);
                }
            }

        }
    }

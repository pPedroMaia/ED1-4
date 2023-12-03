using System;
using System.Collections.Generic;

public class Equipamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

public class TipoEquipamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();
}

public class Contrato
{
    public int Numero { get; set; }
    public DateTime DataSaida { get; set; }
    public DateTime DataRetorno { get; set; }
    public List<TipoEquipamento> EquipamentosContratados { get; set; } = new List<TipoEquipamento>();
    public bool Liberado { get; set; }
}

public class Locadora
{
    private List<TipoEquipamento> tiposEquipamento = new List<TipoEquipamento>();
    private List<Contrato> contratos = new List<Contrato>();

    public void CadastrarTipoEquipamento(string nome)
    {
        var tipo = new TipoEquipamento { Id = tiposEquipamento.Count + 1, Nome = nome };
        tiposEquipamento.Add(tipo);
    }

    public void ConsultarTiposEquipamento()
    {
        foreach (var tipo in tiposEquipamento)
        {
            Console.WriteLine($"ID: {tipo.Id}, Nome: {tipo.Nome}");
            Console.WriteLine("Equipamentos:");

            foreach (var equipamento in tipo.Equipamentos)
            {
                Console.WriteLine($"  ID: {equipamento.Id}, Nome: {equipamento.Nome}");
            }
            Console.WriteLine();
        }
    }

    public void CadastrarEquipamento(int tipoId, string nomeEquipamento)
    {
        var tipo = tiposEquipamento.Find(t => t.Id == tipoId);

        if (tipo != null)
        {
            var equipamento = new Equipamento { Id = tipo.Equipamentos.Count + 1, Nome = nomeEquipamento };
            tipo.Equipamentos.Add(equipamento);
            Console.WriteLine($"Equipamento {nomeEquipamento} cadastrado no tipo {tipo.Nome} com sucesso.");
        }
        else
        {
            Console.WriteLine("Tipo de equipamento não encontrado.");
        }
    }

    public void RegistrarContrato(DateTime dataSaida, DateTime dataRetorno, List<int> tiposEquipamentoContratados)
    {
        var contrato = new Contrato
        {
            Numero = contratos.Count + 1,
            DataSaida = dataSaida,
            DataRetorno = dataRetorno
        };

        foreach (var tipoId in tiposEquipamentoContratados)
        {
            var tipo = tiposEquipamento.Find(t => t.Id == tipoId);
            if (tipo != null)
            {
                contrato.EquipamentosContratados.Add(tipo);
            }
            else
            {
                Console.WriteLine($"Tipo de equipamento (ID: {tipoId}) não encontrado. Contrato não registrado.");
                return;
            }
        }

        contratos.Add(contrato);
        Console.WriteLine($"Contrato {contrato.Numero} registrado com sucesso.");
    }

    public void ConsultarContratos()
    {
        foreach (var contrato in contratos)
        {
            Console.WriteLine($"Número do Contrato: {contrato.Numero}");
            Console.WriteLine($"Data de Saída: {contrato.DataSaida}");
            Console.WriteLine($"Data de Retorno: {contrato.DataRetorno}");
            Console.WriteLine($"Liberado: {contrato.Liberado}");
            Console.WriteLine("Equipamentos Contratados:");

            foreach (var tipo in contrato.EquipamentosContratados)
            {
                Console.WriteLine($"  Tipo de Equipamento: {tipo.Nome}");
                Console.WriteLine("    Equipamentos:");

                foreach (var equipamento in tipo.Equipamentos)
                {
                    Console.WriteLine($"      ID: {equipamento.Id}, Nome: {equipamento.Nome}");
                }
            }
            Console.WriteLine();
        }
    }

    public void LiberarContrato(int numeroContrato)
    {
        var contrato = contratos.Find(c => c.Numero == numeroContrato);

        if (contrato != null)
        {
            contrato.Liberado = true;
            Console.WriteLine($"Contrato {numeroContrato} liberado com sucesso.");
        }
        else
        {
            Console.WriteLine($"Contrato {numeroContrato} não encontrado.");
        }
    }

    public void ConsultarContratosLiberados()
    {
        var contratosLiberados = contratos.FindAll(c => c.Liberado);

        foreach (var contrato in contratosLiberados)
        {
            Console.WriteLine($"Número do Contrato: {contrato.Numero}");
            Console.WriteLine($"Data de Saída: {contrato.DataSaida}");
            Console.WriteLine($"Data de Retorno: {contrato.DataRetorno}");
            Console.WriteLine("Equipamentos Contratados:");

            foreach (var tipo in contrato.EquipamentosContratados)
            {
                Console.WriteLine($"  Tipo de Equipamento: {tipo.Nome}");
                Console.WriteLine("    Equipamentos:");

                foreach (var equipamento in tipo.Equipamentos)
                {
                    Console.WriteLine($"      ID: {equipamento.Id}, Nome: {equipamento.Nome}");
                }
            }
            Console.WriteLine();
        }
    }

    public void DevolverEquipamentos(int numeroContrato)
    {
        var contrato = contratos.Find(c => c.Numero == numeroContrato);

        if (contrato != null && contrato.Liberado)
        {
            Console.WriteLine($"Equipamentos do Contrato {numeroContrato} devolvidos com sucesso.");
            contratos.Remove(contrato);
        }
        else
        {
            Console.WriteLine($"Contrato {numeroContrato} não encontrado ou não liberado.");
        }
    }
}

class Program
{
    static void Main()
    {
        Locadora locadora = new Locadora();

        int opcao;
        do
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Cadastrar tipo de equipamento");
            Console.WriteLine("2. Consultar tipo de equipamento");
            Console.WriteLine("3. Cadastrar equipamento");
            Console.WriteLine("4. Registrar Contrato de Locação");
            Console.WriteLine("5. Consultar Contratos de Locação");
            Console.WriteLine("6. Liberar de Contrato de Locação");
            Console.WriteLine("7. Consultar Contratos de Locação liberados");
            Console.WriteLine("8. Devolver equipamentos de Contrato de Locação liberado");
            Console.WriteLine("0. Sair");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o nome do tipo de equipamento:");
                        string nomeTipo = Console.ReadLine();
                        locadora.CadastrarTipoEquipamento(nomeTipo);
                        break;

                    case 2:
                        locadora.ConsultarTiposEquipamento();
                        break;

                    case 3:
                        Console.WriteLine("Digite o ID do tipo de equipamento:");
                        if (int.TryParse(Console.ReadLine(), out int tipoId))
                        {
                            Console.WriteLine("Digite o nome do equipamento:");
                            string nomeEquipamento = Console.ReadLine();
                            locadora.CadastrarEquipamento(tipoId, nomeEquipamento);
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Digite a data de saída (formato: dd/mm/yyyy):");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime dataSaida))
                        {
                            Console.WriteLine("Digite a data de retorno (formato: dd/mm/yyyy):");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime dataRetorno))
                            {
                                Console.WriteLine("Digite os IDs dos tipos de equipamento contratados (separados por vírgula):");
                                string[] idsContratados = Console.ReadLine().Split(',');
                                List<int> tiposEquipamentoContratados = new List<int>();

                                foreach (var id in idsContratados)
                                {
                                    if (int.TryParse(id, out int tipoIdContratado))
                                    {
                                        tiposEquipamentoContratados.Add(tipoIdContratado);
                                    }
                                }

                                locadora.RegistrarContrato(dataSaida, dataRetorno, tiposEquipamentoContratados);
                            }
                            else
                            {
                                Console.WriteLine("Data de retorno inválida.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Data de saída inválida.");
                        }
                        break;

                    case 5:
                        locadora.ConsultarContratos();
                        break;

                    case 6:
                        Console.WriteLine("Digite o número do contrato a ser liberado:");
                        if (int.TryParse(Console.ReadLine(), out int numContratoLiberado))
                        {
                            locadora.LiberarContrato(numContratoLiberado);
                        }
                        else
                        {
                            Console.WriteLine("Número de contrato inválido.");
                        }
                        break;

                    case 7:
                        locadora.ConsultarContratosLiberados();
                        break;

                    case 8:
                        Console.WriteLine("Digite o número do contrato a ter os equipamentos devolvidos:");
                        if (int.TryParse(Console.ReadLine(), out int numContratoDevolucao))
                        {
                            locadora.DevolverEquipamentos(numContratoDevolucao);
                        }
                        else
                        {
                            Console.WriteLine("Número de contrato inválido.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Saindo do programa.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        } while (opcao != 0);
    }
}
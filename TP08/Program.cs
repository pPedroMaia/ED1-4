using System;

namespace TP08
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menuexit = false;
            string choice;
            int num;

            Cadastro cadastro = new Cadastro();

            Console.WriteLine("Bem-vindo!\n");

                while (!menuexit)
            {
                Console.WriteLine("\n-|-|-|-|-|-|-|-|-|-|-");
                Console.WriteLine("Selecione uma opção: ");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar ambiente");
                Console.WriteLine("2. Consultar ambiente");
                Console.WriteLine("3. Excluir ambiente");
                Console.WriteLine("4. Cadastrar usuario");
                Console.WriteLine("5. Consultar usuario");
                Console.WriteLine("6. Excluir usuario");
                Console.WriteLine("7. Conceder permissão de acesso ao usuario");
                Console.WriteLine("8. Revogar permissão de acesso ao usuario");
                Console.WriteLine("9. Registrar acesso");
                Console.WriteLine("10. Consultar logs de acesso");
                Console.WriteLine("");

                do
                {
                    Console.WriteLine("Digite a opção desejada: ");
                    choice = Console.ReadLine();
                    Console.WriteLine("");
                } while (!Int32.TryParse(choice, out num) || num < 0 || num > 10);
                Console.WriteLine("");

                switch (num)
                {
                    case 0:
                        menuexit = true;
                        break;

                    case 1:
                        CadastrarAmbiente();
                        break;

                    case 2:
                        ConsultarAmbiente();
                        break;

                    case 3:
                        ExcluirAmbiente();
                        break;

                    case 4:
                        CadastrarUsuario();
                        break;

                    case 5:
                        PesquisarUsuario();
                        break;

                    case 6:
                        ExcluirUsuario();
                        break;

                    case 7:
                        ConcederPermissao();
                        break;

                    case 8:
                        RevogarPermissao();
                        break;

                    case 9:
                        RegistrarAcesso();
                        break;

                    case 10:
                        ConsultarLogs();
                        break;
                }
            }
            Console.WriteLine("Obrigado e volte sempre!\n");
            Console.ReadKey();

            void CadastrarAmbiente()
            {
                int id;
                string nome, choice;

                Console.WriteLine("Cadastrando um ambiente...");
                do
                {
                    Console.WriteLine("Digite o ID do ambiente que deseja cadastrar: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out id));
                Console.WriteLine("");

                Console.WriteLine("Digite o nome do ambiente: ");
                nome = Console.ReadLine();
                Console.WriteLine("");

                Ambiente ambiente = new Ambiente(id, nome);
                cadastro.adicionarAmbiente(ambiente);
                Console.WriteLine("Ambiente cadastrado com sucesso!");
                Console.ReadKey();
            }

            void ConsultarAmbiente()
            {
                int id;
                string choice;

                Console.WriteLine("Pesquisando um ambiente...");
                do
                {
                    Console.WriteLine("Digite o ID do ambiente que deseja pesquisar: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out id));
                Console.WriteLine("");

                Ambiente ambienteprocurado = new Ambiente(id, "");
                Console.WriteLine("Nome do ambiente encontrado: " + cadastro.pesquisarAmbiente(ambienteprocurado).Nome + "\n");
            }

            void ExcluirAmbiente()
            {
                int id;
                string choice;

                Console.WriteLine("Excluindo um ambiente...");
                do
                {
                    Console.WriteLine("Digite o ID do ambiente que deseja excluir: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out id));
                Console.WriteLine("");

                Ambiente ambienteexcluido = new Ambiente(id, "");
                Ambiente ambientencontrado = cadastro.pesquisarAmbiente(ambienteexcluido);
                cadastro.removerAmbiente(ambientencontrado);
            }

            void CadastrarUsuario()
            {
                int id;
                string choice, nome;

                Console.WriteLine("Cadastrando um usuário...");
                do
                {
                    Console.WriteLine("Digite o ID do usuário que deseja cadastrar: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out id));
                Console.WriteLine("");

                Console.WriteLine("Digite o nome do usuário: ");
                nome = Console.ReadLine();
                Console.WriteLine("");

                Usuario novousuario = new Usuario(id, nome);
                cadastro.adicionarUsuario(novousuario);
                Console.WriteLine("Usuário cadastrado com sucesso!\n");
            }

            void PesquisarUsuario()
            {
                int id;
                string choice;

                Console.WriteLine("Pesquisando um usuário...");

                do
                {
                    Console.WriteLine("Digite o ID do usuário que deseja pesquisar: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out id));
                Console.WriteLine("");

                Usuario usuariopesquisado = new Usuario(id, "");

                Console.WriteLine("Usuário encontrado: " + cadastro.pesquisarUsuario(usuariopesquisado).ToString());
            }

            void ExcluirUsuario()
            {
                int id;
                string choice;

                Console.WriteLine("Excluindo um usuário...");

                do
                {
                    Console.WriteLine("Digite o ID do usuário que deseja excluir: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out id));
                Console.WriteLine("");

                Usuario usuarioexcluir = new Usuario(id, "");

                cadastro.removerUsuario(usuarioexcluir);
            }

            void ConcederPermissao()
            {
                int id;
                string choice;

                Console.WriteLine("Concedendo permissão a um usuário...");

                do
                {
                    Console.WriteLine("Digite o ID do usuário que deseja conceder a permissão: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out id));
                Console.WriteLine("");

                Usuario usuarioconcedido = new Usuario(id, "");
                Usuario usuarioencontrado = cadastro.pesquisarUsuario(usuarioconcedido);

                if (usuarioencontrado.Nome == "")
                {
                    Console.WriteLine("Erro! Usuário não encontrado, cancelando operação...");
                }
                else
                {
                    Console.WriteLine("Usuário encontrado: " + usuarioencontrado.ToString()+"\n");

                    do
                    {
                        Console.WriteLine("Digite o ID do ambiente que deseja conceder a permissão: ");
                        choice = Console.ReadLine();
                    } while (!Int32.TryParse(choice, out id));
                    Console.WriteLine("");

                    Ambiente ambienteconcedido = new Ambiente(id, "");
                    Ambiente ambientencontrado = cadastro.pesquisarAmbiente(ambienteconcedido);

                    if (ambientencontrado.Nome == "")
                    {
                        Console.WriteLine("Erro! Ambiente não encontrado, cancelando operação...");
                    }
                    else
                    {
                        Console.WriteLine("Ambiente encontrado: " + ambientencontrado.ToString() + "\n");

                        cadastro.Usuarios[cadastro.Usuarios.IndexOf(usuarioencontrado)].concederPermissao(ambientencontrado);
                    }

                }                          
            }

            void RevogarPermissao()
            {
                int id;
                string choice;

                Console.WriteLine("Revogando permissão a um usuário...");

                do
                {
                    Console.WriteLine("Digite o ID do usuário que deseja revogar a permissão: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out id));
                Console.WriteLine("");

                Usuario usuariorevogado = new Usuario(id, "");
                Usuario usuarioencontrado = cadastro.pesquisarUsuario(usuariorevogado);

                if (usuarioencontrado.Nome == "")
                {
                    Console.WriteLine("Erro! Usuário não encontrado, cancelando operação...");
                }
                else
                {
                    Console.WriteLine("Usuário encontrado: " + usuarioencontrado.ToString() + "\n");

                    do
                    {
                        Console.WriteLine("Digite o ID do ambiente que deseja revogar a permissão: ");
                        choice = Console.ReadLine();
                    } while (!Int32.TryParse(choice, out id));
                    Console.WriteLine("");

                    Ambiente ambienterevogado = new Ambiente(id, "");
                    Ambiente ambientencontrado = cadastro.pesquisarAmbiente(ambienterevogado);

                    if (ambientencontrado.Nome == "")
                    {
                        Console.WriteLine("Erro! Ambiente não encontrado, cancelando operação...");
                    }
                    else
                    {
                        Console.WriteLine("Ambiente encontrado: " + ambientencontrado.ToString() + "\n");

                        cadastro.Usuarios[cadastro.Usuarios.IndexOf(usuarioencontrado)].revogarpermissao(ambientencontrado);
                    }

                }
            }

            void RegistrarAcesso()
            {
                int id;
                string choice;

                Console.WriteLine("Registrando um acesso...");

                do
                {
                    Console.WriteLine("Digite o ID do usuário que deseja acessar: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out id));
                Console.WriteLine("");

                Usuario usuarioacessado = new Usuario(id, "");
                Usuario usuarioencontrado = cadastro.pesquisarUsuario(usuarioacessado);

                if (usuarioencontrado.Nome == "")
                {
                    Console.WriteLine("Erro! Usuário não encontrado, cancelando operação...");
                }
                else
                {
                    Console.WriteLine("Usuário encontrado: " + usuarioencontrado.ToString() + "\n");

                    do
                    {
                        Console.WriteLine("Digite o ID do ambiente que deseja acessar: ");
                        choice = Console.ReadLine();
                    } while (!Int32.TryParse(choice, out id));
                    Console.WriteLine("");

                    Ambiente ambienteacessado = new Ambiente(id, "");
                    Ambiente ambientencontrado = cadastro.pesquisarAmbiente(ambienteacessado);

                    if (ambientencontrado.Nome == "")
                    {
                        Console.WriteLine("Erro! Ambiente não encontrado, cancelando operação...");
                    }
                    else
                    {
                        Console.WriteLine("Ambiente encontrado: " + ambientencontrado.ToString() + "\n");

                        Log acesso=new Log(DateTime.Now,usuarioencontrado,true);
                        cadastro.Ambientes[cadastro.Ambientes.IndexOf(ambientencontrado)].registrarLog(acesso);
                        Console.WriteLine("Log registrado com acesso autorizado!");
                    }

                }
            }

            void ConsultarLogs()
            {
                int id,tipoacesso;
                string choice;

                Console.WriteLine("Consultando logs de acesso...");

                do
                {
                    Console.WriteLine("Digite o ID do ambiente que deseja pesquisar: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out id));
                Console.WriteLine("");

                Ambiente ambienteacessado = new Ambiente(id, "");
                Ambiente ambientencontrado = cadastro.pesquisarAmbiente(ambienteacessado);

                if (ambientencontrado.Nome == "")
                {
                    Console.WriteLine("Erro! Ambiente não encontrado, cancelando operação...");
                }
                else
                {
                    Console.WriteLine("Ambiente encontrado: " + ambientencontrado.ToString() + "\n");

                    do
                    {
                        Console.WriteLine("Digite o tipo de filtro de autorização que deseja utilizar: (0) para negados / (1) para autorizados / (2) para todos");
                        Console.WriteLine("Digite uma das três opções:");
                        choice = Console.ReadLine();
                    } while (!Int32.TryParse(choice, out tipoacesso)&&tipoacesso<0&&tipoacesso >2);
                    Console.WriteLine("");

                    Console.WriteLine("Listando os logs de acesso: ");
                    cadastro.Ambientes[cadastro.Ambientes.IndexOf(ambientencontrado)].consultarLog(tipoacesso);
                }
            }
        }
    }
}

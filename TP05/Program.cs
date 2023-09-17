using System;

namespace TP05
{
    class Program
{
    static void Main(string[] args)
    {
        bool menuexit = false;
        string choice;
        int num;

        Livros livros = new Livros();

        Console.WriteLine("Bem vindo!");
        Console.WriteLine("");

        while (!menuexit)
        {
            Console.WriteLine("");
            Console.WriteLine("Selecione uma opção: ");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar livro");
            Console.WriteLine("2. Pesquisar livro (sintético)");
            Console.WriteLine("3. Pesquisar livro (analítico)");
            Console.WriteLine("4. Adicionar exemplar");
            Console.WriteLine("5. Registrar empréstimo");
            Console.WriteLine("6. Registrar devolução");
            Console.WriteLine("");

            do
            {
                Console.WriteLine("Digite a opção desejada: ");
                choice = Console.ReadLine();
                Console.WriteLine("");
            } while (!Int32.TryParse(choice, out num) || num < 0 || num > 6);

            Console.WriteLine("");

            switch (num)
            {
                case 0:
                    menuexit = true;
                    break;

                case 1:
                    AdicionarLivro();
                    break;

                case 2:
                    PesqLivroSint();
                    break;

                case 3:
                    PesqLivroAnal();
                    break;

                case 4:
                    AddExemplar();
                    break;

                case 5:
                    RegistrarEmprestimo();
                    break;

                case 6:
                    RegistrarDevolucao();
                    break;
            }
        }

        Console.WriteLine("Obrigado e volte sempre!");
        Console.WriteLine("");

        Console.ReadKey();

        void AdicionarLivro()
        {
            int isbn;
            string titulo, autor, editora, choice;

            Console.WriteLine("Adicionando um livro...");

            do
            {
                Console.WriteLine("Digite o código ISBN do livro: ");
                choice = Console.ReadLine();
            } while (!Int32.TryParse(choice, out isbn));
            Console.WriteLine("");

            Console.WriteLine("Digite o título do livro: ");
            titulo = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Digite o nome do autor do livro: ");
            autor = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Digite o nome da editora do livro: ");
            editora = Console.ReadLine();
            Console.WriteLine("");

            Livro livrocadastrado = new Livro(isbn, titulo, autor, editora);
            livros.Acervo.Add(livrocadastrado);
            Console.WriteLine("Livro cadastrado com sucesso!\n");
            Console.ReadKey();
        }

        void PesqLivroSint()
        {
            Console.WriteLine("Pesquisa de livros (sintético)");
            if (livros.Acervo.Count > 0)
            {
                foreach (Livro l in livros.Acervo)
                {
                    Console.WriteLine("\nDados do livro: ");
                    Console.WriteLine(l.ToString());
                    Console.WriteLine("Total de exemplares: " + l.qtdeExemplares() + ".");
                    Console.WriteLine("Total de exemplares disponíveis: " + l.qtdeDisponiveis() + ".");
                    Console.WriteLine("Total de empréstimos realizados: " + l.qtdeEmprestimos() + ".");
                    Console.WriteLine("Percentual de disponibilidade: " + l.percDisponibilidade() + "%.");
                    Console.WriteLine("-----\n");
                }
            }

            else
            {
                Console.WriteLine("Sem livros cadastrados no sistema!\n");
            }

        }

        void PesqLivroAnal()
        {
            Console.WriteLine("Pesquisa de livros (analítico)");
            if (livros.Acervo.Count > 0)
            {
                foreach (Livro l in livros.Acervo)
                {
                    Console.WriteLine("\nDados do livro: ");
                    Console.WriteLine(l.ToString());
                    Console.WriteLine("Total de exemplares: " + l.qtdeExemplares() + ".");
                    Console.WriteLine("Total de exemplares disponíveis: " + l.qtdeDisponiveis() + ".");
                    Console.WriteLine("Total de empréstimos realizados: " + l.qtdeEmprestimos() + ".");
                    Console.WriteLine("Percentual de disponibilidade: " + l.percDisponibilidade() + "%.");
                    Console.WriteLine("Dados do(s) exemplar(es): ");
                    if (l.Exemplares.Count > 0)
                    {
                        foreach (Exemplar e in l.Exemplares)
                        {
                            Console.WriteLine(e.ToString());
                            foreach (Emprestimo em in e.Emprestimos)
                            {
                                Console.WriteLine(em.ToString());
                            }
                        }
                        Console.WriteLine("-----\n");
                    }
                    else
                    {
                        Console.WriteLine("Sem exemplares cadastrados no sistema!\n");
                    }
                }
            }

            else
            {
                Console.WriteLine("Sem livros cadastrados no sistema!\n");
            }

        }

        void AddExemplar()
        {
            int isbn, tombo;
            string choice;

            Console.WriteLine("Adicionando um exemplar...");

            do
            {
                Console.WriteLine("Digite o código ISBN do livro que deseja adicionar um exemplar: ");
                choice = Console.ReadLine();
            } while (!Int32.TryParse(choice, out isbn));
            Console.WriteLine("");

            Livro livroprocurado = new Livro(isbn, "", "", "");
            Livro livroencontrado = livros.pesquisar(livroprocurado);
            if (livroencontrado.Isbn == 0)
            {
                Console.WriteLine("Livro não encontrado! Cancelando operação...\n");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("Dados do livro: ");
                Console.WriteLine(livroencontrado.ToString());
                Console.WriteLine("");
                do
                {
                    Console.WriteLine("Agora digite o número tombo do exemplar: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out tombo));
                Console.WriteLine("");

                Exemplar exemplar = new Exemplar(tombo);
                livros.Acervo[livros.pesquisar2(livroprocurado)].adicionarExemplar(exemplar);
                Console.WriteLine("Exemplar cadastrado com sucesso!\n");
                Console.ReadKey();

            }

        }

        void RegistrarEmprestimo()
        {
            int isbn, tombo;
            string choice;
            DateTime data = DateTime.Today;

            Console.WriteLine("Registrando um empréstimo...");

            do
            {
                Console.WriteLine("Digite o código ISBN do livro que deseja registrar um empréstimo: ");
                choice = Console.ReadLine();
            } while (!Int32.TryParse(choice, out isbn));
            Console.WriteLine("");

            Livro livroprocurado = new Livro(isbn, "", "", "");
            Livro livroencontrado = livros.pesquisar(livroprocurado);
            if (livroencontrado.Isbn == 0)
            {
                Console.WriteLine("Livro não encontrado! Cancelando operação...\n");
                Console.ReadKey();
            }

            else
            {
                do
                {
                    Console.WriteLine("Digite o número tombo do exemplar que deseja registrar um empréstimo: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out tombo));
                Console.WriteLine("");

                Exemplar exemplarprocurado = new Exemplar(tombo);
                Exemplar exemplarencontrado = livros.Acervo[livros.pesquisar2(livroencontrado)].pesquisar(exemplarprocurado);
                if (exemplarencontrado.Tombo == 0)
                {
                    Console.WriteLine("Exemplar não encontrado! Cancelando operação...\n");
                    Console.ReadKey();
                }

                else
                {
                    Emprestimo emprestimo = new Emprestimo(data);
                    Console.WriteLine(livros.Acervo[livros.pesquisar2(livroencontrado)].Exemplares[livros.Acervo[livros.pesquisar2(livroencontrado)].pesquisar2(exemplarencontrado)].emprestar(emprestimo) ? "Exemplar emprestado com sucesso!" : "Exemplar já emprestado!");
                    Console.ReadKey();
                }

            }
        }

        void RegistrarDevolucao()
        {
            int isbn, tombo;
            string choice;
            DateTime data = DateTime.Today;

            Console.WriteLine("Registrando uma devolução...");

            do
            {
                Console.WriteLine("Digite o código ISBN do livro que deseja registrar a devolução: ");
                choice = Console.ReadLine();
            } while (!Int32.TryParse(choice, out isbn));
            Console.WriteLine("");

            Livro livroprocurado = new Livro(isbn, "", "", "");
            Livro livroencontrado = livros.pesquisar(livroprocurado);
            if (livroencontrado.Isbn == 0)
            {
                Console.WriteLine("Livro não encontrado! Cancelando operação...\n");
                Console.ReadKey();
            }

            else
            {
                do
                {
                    Console.WriteLine("Digite o número tombo do exemplar que deseja registrar um empréstimo: ");
                    choice = Console.ReadLine();
                } while (!Int32.TryParse(choice, out tombo));
                Console.WriteLine("");

                Exemplar exemplarprocurado = new Exemplar(tombo);
                Exemplar exemplarencontrado = livros.Acervo[livros.pesquisar2(livroencontrado)].pesquisar(exemplarprocurado);
                if (exemplarencontrado.Tombo == 0)
                {
                    Console.WriteLine("Exemplar não encontrado! Cancelando operação...\n");
                    Console.ReadKey();
                }

                else
                {
                    if (exemplarencontrado.Disponivel == true)
                    {
                        Console.WriteLine("Exemplar não emprestado! Cancelando operação...\n");
                        Console.ReadKey();
                    }

                    else
                    {
                        Emprestimo emprestimo = new Emprestimo(exemplarencontrado.Emprestimos[exemplarencontrado.Emprestimos.Count - 1].DtEmprestimo, data);
                        Console.WriteLine(livros.Acervo[livros.pesquisar2(livroencontrado)].Exemplares[livros.Acervo[livros.pesquisar2(livroencontrado)].pesquisar2(exemplarencontrado)].devolver(emprestimo) ? "Exemplar devolvido com sucesso!" : "Exemplar já devolvido!");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
}
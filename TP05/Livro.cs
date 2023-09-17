using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP05
{
    class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        public int Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Editora { get => editora; set => editora = value; }
        public List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            this.exemplares = new List<Exemplar>();
        }

        public Livro()
        {
            this.isbn = 0;
            this.titulo = "";
            this.autor = "";
            this.editora = "";
            this.exemplares = new List<Exemplar>();
        }

        public void adicionarExemplar(Exemplar exemplar)
        {
            this.exemplares.Add(exemplar);
        }

        public int qtdeExemplares()
        {
            int qtde = this.exemplares.Count;
            return qtde;
        }

        public int qtdeDisponiveis()
        {
            int qtdeDisponiveis = 0;
            foreach (Exemplar e in this.exemplares)
            {
                if (e.Disponivel == true)
                {
                    qtdeDisponiveis++;
                }
            }
            return qtdeDisponiveis;
        }

        public int qtdeEmprestimos()
        {
            int qtdeEmprestimos = 0;
            foreach (Exemplar e in this.exemplares)
            {
                qtdeEmprestimos += e.Emprestimos.Count;
            }
            return qtdeEmprestimos;
        }

        public double percDisponibilidade()
        {
            double percDisponibilidade = 0;
            double qtde = this.exemplares.Count;
            double qtdeDisponiveis = 0;
            foreach (Exemplar e in exemplares)
            {
                if (e.Disponivel == true)
                {
                    qtdeDisponiveis++;
                }
            }
            if (qtde > 0)
            {
                percDisponibilidade = (qtdeDisponiveis / qtde) * 100;
            }
            return percDisponibilidade;
        }

        public Exemplar pesquisar(Exemplar exemplar)
        {
            Exemplar exemplarencontrado = new Exemplar();
            foreach (Exemplar e in exemplares)
            {
                if (e.Tombo.Equals(exemplar.Tombo))
                {
                    exemplarencontrado = e;
                }
            }
            return exemplarencontrado;
        }

        public int pesquisar2(Exemplar exemplar)
        {
            int indice = 0;
            foreach (Exemplar e in exemplares)
            {
                if (e.Tombo.Equals(exemplar.Tombo))
                {
                    indice = exemplares.IndexOf(e);
                }
            }
            return indice;
        }

        public override string ToString()
        {
            return "ISBN: " + this.isbn + "\nTítulo: " + this.titulo + "\nAutor: " + this.autor + "\nEditora: " + this.editora;
        }

        public override bool Equals(object obj)
        {
            return this.isbn.Equals(((Livro)obj).Isbn);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

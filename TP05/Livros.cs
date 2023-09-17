using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP05
{
    class Livros
    {
        private List<Livro> acervo;

        public List<Livro> Acervo { get => acervo; set => acervo = value; }

        public Livros()
        {
            this.acervo = new List<Livro>();
        }

        public Livro pesquisar(Livro livro)
        {
            Livro livroencontrado = new Livro();

            foreach (Livro l in acervo)
            {
                if (l.Isbn.Equals(livro.Isbn))
                {
                    livroencontrado = l;
                }
            }

            return livroencontrado;
        }

        public int pesquisar2(Livro livro)
        {
            int indice = 0;
            foreach (Livro l in acervo)
            {
                if (l.Isbn.Equals(livro.Isbn))
                {
                    indice = acervo.IndexOf(l);
                }
            }
            return indice;
        }
    }
}

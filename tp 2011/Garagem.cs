using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoTransporte
{
    class Garagem
    {
        int id;
        static int temp = 1;
        static int Incrementar()
        {
            return temp++;
        }

        string local;
        public Stack<Veiculo> veiculos;

        public int Id { get { return id; } }
        public string Local { get { return local; } set { local = value; } }

        internal Stack<Veiculo> Veiculos { get => veiculos; set => veiculos = value; }

        public Garagem(int id) : this("")
        {

        }

        public Garagem(string local)
        {
            this.veiculos = new Stack<Veiculo>();
            this.Local = local;
            this.id = Incrementar();
        }


        public int qtdeVeiculos()
        {
            return this.veiculos.Count();
        }

        public int potencialDeTransporte()
        {
            int potencial = 0;
            foreach (Veiculo v in this.veiculos)
            {
                potencial += v.Lotacao;
            }
            return potencial;
        }


        public override bool Equals(object obj)
        {
            Garagem g = (Garagem)obj;
            return this.Local.Equals(g.Local);
        }
    }
}
